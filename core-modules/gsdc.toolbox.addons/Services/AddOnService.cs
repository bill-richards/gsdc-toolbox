using System.Linq;
using Prism.Modularity;

namespace gsdc.toolbox.addons.Services
{
    internal class AddOnService : IAddOnService
    {
        private readonly IModuleManager _moduleManager;

        public AddOnService(IModuleManager moduleManager, IModuleCatalog loadedCatalog)
        {
            _moduleManager = moduleManager;
            LoadedCatalog = loadedCatalog;
        }

        public void LoadAddOns(string directory)
        {
            var temporaryCatalog = new DirectoryModuleCatalog { ModulePath = directory };
            temporaryCatalog.Load();
            foreach (var info in temporaryCatalog.Modules)
            {
                if (LoadedCatalog.Modules.Any(m => m.ModuleName.Equals(info.ModuleName)))
                    continue;

                info.InitializationMode = InitializationMode.OnDemand;
                LoadedCatalog.AddModule(info);
            }

            LoadedCatalog.Initialize();
            foreach (var info in temporaryCatalog.Modules)
            {
                _moduleManager.LoadModule(info.ModuleName);
            }
        }

        private IModuleCatalog LoadedCatalog { get; }
    }
}
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Prism.Modularity;

namespace gsdc.toolbox.module.loader.services
{
    internal class ModuleLoader : IModuleLoader
    {
        private readonly IModuleManager _moduleManager;
        private readonly IModuleCatalog _loadedCatalog;
        private List<IModuleInfo> _modulesAddedToCatalog;

        public ModuleLoader(IModuleManager moduleManager, IModuleCatalog loadedCatalog)
        {
            _moduleManager = moduleManager;
            _loadedCatalog = loadedCatalog;
        }

        public void ScanAndLoadModules(string path, bool doNotScanImmediateChildDirectories = false)
        {
            _modulesAddedToCatalog = new List<IModuleInfo>(AddModulesToTheCatalog(path));

            if(!doNotScanImmediateChildDirectories)
                ScanImmediateChildDirectories(path);

            _modulesAddedToCatalog.Reverse();
            LoadCatalogModules();
        }

        private void ScanImmediateChildDirectories(string path)
        {
            foreach (var moduleFolder in Directory.GetDirectories(path))
                _modulesAddedToCatalog.AddRange(AddModulesToTheCatalog(moduleFolder));
        }

        private IEnumerable<IModuleInfo> AddModulesToTheCatalog(string directory)
        {
            var temporaryCatalog = new DirectoryModuleCatalog { ModulePath = directory };
            temporaryCatalog.Load();
            foreach (var info in temporaryCatalog.Modules)
            {
                if (_loadedCatalog.Modules.Any(m => m.ModuleName.Equals(info.ModuleName)))
                    continue;

                info.InitializationMode = InitializationMode.OnDemand;
                _loadedCatalog.AddModule(info);
            }

            return temporaryCatalog.Modules;
        }

        private void LoadCatalogModules()
        {
            _loadedCatalog.Initialize();
            var retry = false;
            var count = 0;
            var numberOfModulesToAdd = _modulesAddedToCatalog.Count;
            do
            {
                try
                {
                    foreach (var info in _modulesAddedToCatalog)
                    {
                        _moduleManager.LoadModule(info.ModuleName);
                        _modulesAddedToCatalog.Remove(info);
                    }
                }
                catch
                {
                    retry = true;
                    count++;
                }
            } while (retry && count < numberOfModulesToAdd);
        }
    }
}
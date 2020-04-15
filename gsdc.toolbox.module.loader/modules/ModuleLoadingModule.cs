using gsdc.toolbox.module.loader.comparers;
using gsdc.toolbox.module.loader.factories;
using gsdc.toolbox.module.loader.services;
using gsdc.toolbox.modules;
using Prism.Ioc;
using Prism.Modularity;

namespace gsdc.toolbox.module.loader.modules
{
    [Module(ModuleName = ModuleDescription.ModuleName)]
    public class ModuleLoadingModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) => 
            containerProvider.Resolve<IModuleLoader>().ScanAndLoadModules(containerProvider.Resolve<IApplicationService>().CoreModulesDirectory);

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IModuleInfoComparer, ModuleInfoComparer>();

            containerRegistry.Register<IModuleLoader, ModuleLoader>();
            containerRegistry.Register<IModuleLocator, ModuleLocator>();
            containerRegistry.Register<IModuleInfoFactory, ModuleInfoFactory>();
        }
    }
}
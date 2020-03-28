using gsdc.toolbox.module.loader.services;
using Prism.Ioc;
using Prism.Modularity;

namespace gsdc.toolbox.module.loader.modules
{
    public class CoreModuleLoadingModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) => 
            containerProvider.Resolve<IModuleLoader>().ScanAndLoadModules(containerProvider.Resolve<IApplicationService>().CoreModulesDirectory);

        public void RegisterTypes(IContainerRegistry containerRegistry) 
            => containerRegistry.Register<IModuleLoader, ModuleLoader>();
    }
}
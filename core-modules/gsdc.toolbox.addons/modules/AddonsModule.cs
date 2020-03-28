using gsdc.toolbox.addons.services;
using Prism.Ioc;
using Prism.Modularity;

namespace gsdc.toolbox.addons.modules
{
    [ModuleDependency("MenubarModule")]
    [ModuleDependency("CoreModuleLoadingModule")]
    public class AddonsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) 
            => containerProvider.Resolve<AddOnsMenuBuilderService>();

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAddOnService, AddOnService>();
            containerRegistry.RegisterSingleton<AddOnsMenuBuilderService>();
        }
    }
}
using gsdc.toolbox.addons.Services;
using Prism.Ioc;
using Prism.Modularity;

namespace gsdc.toolbox.addons
{
    [ModuleDependency("MenubarModule")]
    public class AddonsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            containerProvider.Resolve<MenuBuilderService>();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAddOnService, AddOnService>();
            containerRegistry.RegisterSingleton<MenuBuilderService>();
        }
    }
}
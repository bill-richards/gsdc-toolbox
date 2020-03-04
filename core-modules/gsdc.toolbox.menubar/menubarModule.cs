using gsdc.toolbox.menubar.Factories;
using gsdc.toolbox.menubar.Services;
using gsdc.toolbox.menubar.ViewModels;
using gsdc.toolbox.menubar.Views;
using gsdc.toolbox.menus;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace gsdc.toolbox.menubar
{
    public class MenubarModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.ShellToolboxMenuHolder, typeof(MenuBar));

            containerProvider.Resolve<MenuBuilderService>();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMenuService, MenuService>();
            containerRegistry.RegisterSingleton<MenuBuilderService>();
            containerRegistry.RegisterSingleton<IMenuInfoFactory, MenuInfo>();
            containerRegistry.RegisterSingleton<IMenuItemFactory, MenuItemFactory>();
            containerRegistry.RegisterSingleton<IMenuItemViewModelFactory, MenuItemViewModel>();
        }
    }
}
using gsdc.toolbox.menubar.Events;
using gsdc.toolbox.menubar.Factories;
using gsdc.toolbox.menubar.Services;
using gsdc.toolbox.menubar.ViewModels;
using gsdc.toolbox.menubar.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace gsdc.toolbox.menubar.Modules
{
    public class MenubarModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.ShellToolboxMenuHolder, typeof(MenuBar));
            containerProvider.Resolve<MenuBarMenuBuilderService>();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMenuRegistrar, MenuRegistrar>();
            containerRegistry.RegisterSingleton<MenuBarMenuBuilderService>();
            containerRegistry.RegisterSingleton<IMenuInfoFactory, MenuInfo>();
            containerRegistry.RegisterSingleton<IMenuItemFactory, MenuItemFactory>();
            containerRegistry.RegisterSingleton<IMenuFacade, MenuFacade>();
            
            containerRegistry.RegisterSingleton<IMenuItemViewModelFactory, MenuItemViewModel>();
            containerRegistry.RegisterSingleton<IMenuVisibilityEventFacade, MenuVisibilityEventFacade>();
            containerRegistry.RegisterSingleton<MenuVisibilityEventArgs>();
            containerRegistry.RegisterSingleton<MenuService>();

            containerRegistry.Register<IMenuService, MenuService>();
            containerRegistry.Register<IMenuServiceInterpreter, MenuService>();
            containerRegistry.Register<IMenuVisibilityEventPublisher, MenuVisibilityEventArgs>();
            containerRegistry.Register<IMenuVisibilityEventSubscriber, MenuVisibilityEventArgs>();
        }
    }
}
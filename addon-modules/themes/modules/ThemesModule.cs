using Prism.Ioc;
using Prism.Modularity;
using themes.services;

namespace themes.modules
{
    public class ThemesModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) 
            => containerProvider.Resolve<MenuBuilderService>();

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<MenuBuilderService>();
            containerRegistry.RegisterSingleton<IThemeFinderService, ThemeFinderService>();
            containerRegistry.RegisterSingleton<IThemeFactory, Theme>();

            containerRegistry.Register<IThemeApplicationService, ThemeApplicationService>();
            containerRegistry.Register<IThemeCacheService, ThemeCacheService>();
        }
    }
}
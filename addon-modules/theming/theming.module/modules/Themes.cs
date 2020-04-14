using Prism.Ioc;
using Prism.Modularity;
using toolbox.themes.services;

namespace toolbox.themes.modules
{
    [Module(ModuleName = ModuleDescription.ModuleName)]
    public class Themes : IModule
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
using Prism.Ioc;
using Prism.Modularity;
using toolbox.themes.services;

namespace toolbox.themes.modules
{
    [Module(ModuleName = ModuleDescription.ModuleName)]
    public class Themes : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) 
            => containerProvider.Resolve<MenubarConstructionService>();

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<MenubarConstructionService>();
            containerRegistry.RegisterSingleton<IThemeFinderService, ThemeFinderService>();
            containerRegistry.RegisterSingleton<IThemeFactory, Theme>();

            containerRegistry.Register<IThemeApplicationService, ThemeApplicationService>();
            containerRegistry.Register<IThemeCacheService, ThemeCacheService>();
        }
    }
}
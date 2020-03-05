using Prism.Ioc;
using Prism.Modularity;
using shiny.themes.services;

namespace shiny.themes.modules
{
    [ModuleDependency("ThemesModule")]
    public class ShinyThemesModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) 
            => containerProvider.Resolve<MenuBuilderService>();

        public void RegisterTypes(IContainerRegistry containerRegistry) 
            => containerRegistry.RegisterSingleton<MenuBuilderService>();
    }
}
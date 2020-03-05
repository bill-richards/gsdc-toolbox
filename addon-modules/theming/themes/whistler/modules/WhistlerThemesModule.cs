using Prism.Ioc;
using Prism.Modularity;
using whistler.themes.services;

namespace whistler.themes.modules
{
    [ModuleDependency("ThemesModule")]
    public class WhistlerThemesModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) 
            => containerProvider.Resolve<MenuBuilderService>();

        public void RegisterTypes(IContainerRegistry containerRegistry) 
            => containerRegistry.RegisterSingleton<MenuBuilderService>();
    }
}
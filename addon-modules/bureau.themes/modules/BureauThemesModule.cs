using Prism.Ioc;
using Prism.Modularity;
using bureau.themes.services;

namespace bureau.themes.modules
{
    [ModuleDependency("ThemesModule")]
    public class BureauThemesModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) 
            => containerProvider.Resolve<MenuBuilderService>();

        public void RegisterTypes(IContainerRegistry containerRegistry) 
            => containerRegistry.RegisterSingleton<MenuBuilderService>();
    }
}
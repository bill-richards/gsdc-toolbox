using cnl.themes.services;
using Prism.Ioc;
using Prism.Modularity;

namespace cnl.themes.modules
{
    [ModuleDependency("ThemesModule")]
    public class CnlThemesModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) 
            => containerProvider.Resolve<MenuBuilderService>();

        public void RegisterTypes(IContainerRegistry containerRegistry) 
            => containerRegistry.RegisterSingleton<MenuBuilderService>();
    }
}
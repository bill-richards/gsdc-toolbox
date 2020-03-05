using expression.themes.services;
using Prism.Ioc;
using Prism.Modularity;

namespace expression.themes.modules
{
    [ModuleDependency("ThemesModule")]
    public class ExpressionThemesModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) 
            => containerProvider.Resolve<MenuBuilderService>();

        public void RegisterTypes(IContainerRegistry containerRegistry) 
            => containerRegistry.RegisterSingleton<MenuBuilderService>();
    }
}
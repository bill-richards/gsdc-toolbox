using Prism.Ioc;
using Prism.Modularity;
using themes.whistler.services;

namespace themes.whistler.modules
{
    [Module(ModuleName = ModuleDescription.ModuleName)]
    [ModuleDependency(ModuleDescription.ThemesModuleName)]
    public class Module : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) 
            => containerProvider.Resolve<MenuBuilderService>();

        public void RegisterTypes(IContainerRegistry containerRegistry) 
            => containerRegistry.RegisterSingleton<MenuBuilderService>();
    }
}
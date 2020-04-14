using Prism.Ioc;
using Prism.Modularity;
using themes.shiny.services;

namespace themes.shiny.modules
{
    [Module(ModuleName = ModuleDescription.ModuleName)]
    [ModuleDependency(ModuleDescription.ThemesModuleName)]
    public class Module : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) 
            => containerProvider.Resolve<MenubarConstructionService>();

        public void RegisterTypes(IContainerRegistry containerRegistry) 
            => containerRegistry.RegisterSingleton<MenubarConstructionService>();
    }
}
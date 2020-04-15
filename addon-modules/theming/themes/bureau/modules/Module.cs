using Prism.Ioc;
using Prism.Modularity;
using themes.bureau.services;

namespace themes.bureau.modules
{
    [Module(ModuleName = ModuleDescription.ModuleName)]
    [ModuleDependency(ModuleDescription.ThemesModuleName)]
    [ModuleDependency(ModuleDependencies.Menubar)]
    public class Module : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) 
            => containerProvider.Resolve<MenubarConstructionService>();

        public void RegisterTypes(IContainerRegistry containerRegistry) 
            => containerRegistry.RegisterSingleton<MenubarConstructionService>();
    }
}
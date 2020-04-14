using gsdc.toolbox.addons.services;
using Prism.Ioc;
using Prism.Modularity;

namespace gsdc.toolbox.addons.modules
{
    [Module(ModuleName = ModuleDescription.ModuleName)]
    [ModuleDependency(ModuleDependencies.Dialogs)]
    [ModuleDependency(ModuleDependencies.Menubar)]
    [ModuleDependency(ModuleDependencies.CoreModuleLoading)]
    public class Addons : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) 
            => containerProvider.Resolve<MenubarConstructionService>();

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAddOnService, AddOnService>();
            containerRegistry.RegisterSingleton<MenubarConstructionService>();
            containerRegistry.Register<IAddOnsMenuCommands, AddOnsMenuCommands>();
        }
    }
}
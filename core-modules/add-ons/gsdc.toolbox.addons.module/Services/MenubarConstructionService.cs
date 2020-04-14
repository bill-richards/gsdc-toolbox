using gsdc.toolbox.addons.modules;
using gsdc.toolbox.menubar;

namespace gsdc.toolbox.addons.services
{
    internal class MenubarConstructionService
    {
        public MenubarConstructionService(IMenuInfoFactory infoFactory, IMenuRegistrar menuRegistrar, IMenuService menuService, IAddOnsMenuCommands commands)
        {
            menuRegistrar.AddMenuItem(infoFactory.CreateMenuSeparatorInfo(ToolboxMenuNames.ToolboxMenu));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Add Ons",
                AddOnsMenuNames.MainMenu,
                ToolboxMenuNames.ToolboxMenu).And().SetOwningModuleName(ModuleDescription.ModuleName));
            
            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Load Application Add On Modules",
                AddOnsMenuNames.LoadAdonsMenuItem,
                AddOnsMenuNames.MainMenu,
                "Load all add on modules from the application's add-on-modules directory",
                commands.LoadApplicationAddOnModulesCommand).And().SetOwningModuleName(ModuleDescription.ModuleName));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("Load Add On _Module",
                AddOnsMenuNames.LoadAdonModuleMenuItem,
                AddOnsMenuNames.MainMenu,
                "Load an add on module from a specific location",
                commands.LoadAddOnModuleCommand).And().SetOwningModuleName(ModuleDescription.ModuleName));

            menuService.DisplayThisMenuItem(AddOnsMenuNames.LoadAdonsMenuItem);
            menuService.DisplayThisMenuItem(AddOnsMenuNames.LoadAdonModuleMenuItem);
        }
    }

    
}
using gsdc.toolbox.addons.Views;
using gsdc.toolbox.menubar;
using Prism.Commands;
using Prism.Regions;

namespace gsdc.toolbox.addons.services
{
    internal class AddOnsMenuBuilderService
    {
        public AddOnsMenuBuilderService(IMenuInfoFactory infoFactory, IMenuService menuService, IAddOnService addOnService, IApplicationService applicationService, IRegionManager regionManager)
        {
            menuService.AddMenuItem(infoFactory.CreateMenuSeparatorInfo(ToolboxMenuNames.ToolboxMenu));

            menuService.AddMenuItem(infoFactory.CreateMenuInfo("_Add Ons",
                AddOnsMenuNames.MainMenu,
                ToolboxMenuNames.ToolboxMenu));
            
            menuService.AddMenuItem(infoFactory.CreateMenuInfo("Load Add On _Module",
                AddOnsMenuNames.LoadAdonModuleMenuItem,
                AddOnsMenuNames.MainMenu,
                "Load an add on module from a specific location",
                new DelegateCommand(()=> regionManager.RegisterViewWithRegion(RegionNames.ShellTopRegion, typeof(AddOnModuleLoaderView)))));

            menuService.AddMenuItem(infoFactory.CreateMenuInfo("_Load Application Add On Modules",
                AddOnsMenuNames.LoadAdonsMenuItem,
                AddOnsMenuNames.MainMenu,
                "Load all add on modules from the application's add-on-modules directory",
                new DelegateCommand(() => addOnService.LoadAddOns(applicationService.AddOnsDirectory))));
        }
    }
}
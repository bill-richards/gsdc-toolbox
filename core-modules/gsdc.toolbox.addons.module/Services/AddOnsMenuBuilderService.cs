using gsdc.toolbox.menubar;
using Prism.Commands;

namespace gsdc.toolbox.addons.services
{
    internal class AddOnsMenuBuilderService
    {
        public AddOnsMenuBuilderService(IMenuInfoFactory infoFactory, IMenuService menuService, IAddOnService addOnService, IApplicationService applicationService)
        {
            menuService.AddMenuItem(infoFactory.CreateMenuSeparatorInfo(ToolboxMenuNames.ToolboxMenu));

            menuService.AddMenuItem(infoFactory.CreateMenuInfo("_Add Ons",
                AddOnsMenuNames.MainMenu,
                ToolboxMenuNames.ToolboxMenu));

            menuService.AddMenuItem(infoFactory.CreateMenuInfo("_Load Add Ons",
                AddOnsMenuNames.LoadAdonsMenuItem,
                AddOnsMenuNames.MainMenu,
                "Load all add on modules from the application's add-on-modules directory",
                new DelegateCommand(() => addOnService.LoadAddOns(applicationService.AddOnsDirectory))));
        }
    }
}
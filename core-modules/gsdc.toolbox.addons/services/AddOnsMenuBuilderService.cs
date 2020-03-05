using System.IO;
using gsdc.toolbox.menubar;
using Prism.Commands;

namespace gsdc.toolbox.addons.services
{
    internal class AddOnsMenuBuilderService
    {
        public AddOnsMenuBuilderService(IMenuInfoFactory infoFactory, IMenuService menuService, IAddOnService addOnService)
        {
            menuService.AddMenuItem(infoFactory.CreateMenuSeparatorInfo(ToolboxMenuNames.ToolboxMenu));

            menuService.AddMenuItem(infoFactory.CreateMenuInfo("_Add Ons",
                AddOnsMenuNames.MainMenu,
                ToolboxMenuNames.ToolboxMenu));

            menuService.AddMenuItem(infoFactory.CreateMenuInfo("_Load Add Ons",
                AddOnsMenuNames.LoadAdonsMenuItem,
                AddOnsMenuNames.MainMenu,
                new DelegateCommand(() => addOnService.LoadAddOns($"{Directory.GetCurrentDirectory()}\\add-ons"))));
        }
    }
}
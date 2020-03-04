using System.IO;
using gsdc.toolbox.menus;
using Prism.Commands;
using Prism.Events;

namespace gsdc.toolbox.addons.Services
{
    internal class MenuBuilderService
    {
        public MenuBuilderService(IMenuInfoFactory infoFactory, IEventAggregator eventAggregator, IMenuService menuService, IAddOnService addOnService)
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
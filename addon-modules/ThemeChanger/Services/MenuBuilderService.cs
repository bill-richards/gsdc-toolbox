using gsdc.toolbox.menus;
using Prism.Events;

namespace ThemeChanger.Services
{
    internal class MenuBuilderService
    {
        public MenuBuilderService(IMenuInfoFactory infoFactory, IEventAggregator eventAggregator, IMenuService menuService)
        {
            menuService.AddMenuItem(infoFactory.CreateMenuInfo("The_mes",
                ThemeChangerMenuNames.MainMenu,
                ToolboxMenuNames.ToolboxMenuBar));
        }
    }
}
using gsdc.toolbox.menubar;
using Prism.Commands;

namespace themes.services
{
    internal class MenuBuilderService
    {
        public MenuBuilderService(IMenuInfoFactory infoFactory, IMenuService menuService, IThemeFinderService themeFinder)
        {
            menuService.AddMenuItem(infoFactory.CreateMenuInfo("T_heming",
                ThemingMenuNames.MainMenu,
                ToolboxMenuNames.ToolboxMenuBar));

            menuService.AddMenuItem(infoFactory.CreateMenuInfo("Fin_d Themes",
                ThemingMenuNames.FindThemesMenuItem,
                ThemingMenuNames.MainMenu,
                new DelegateCommand(themeFinder.FindThemes)));

            menuService.AddMenuItem(infoFactory.CreateMenuInfo("A_vailable Themes",
                ThemingMenuNames.ThemeListMenuItem,
                ThemingMenuNames.MainMenu));
        }
    }
}
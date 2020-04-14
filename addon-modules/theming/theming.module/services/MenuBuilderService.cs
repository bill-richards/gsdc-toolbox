using gsdc.toolbox.menubar;
using Prism.Commands;

namespace toolbox.themes.services
{
    internal class MenuBuilderService
    {
        public MenuBuilderService(IMenuInfoFactory infoFactory, IMenuRegistrar menuRegistrar, IThemeFinderService themeFinder, IMenuService menuService)
        {
            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("T_heming",
                                                            ThemingMenuNames.MainMenu,
                                                                ToolboxMenuNames.ToolboxMenuBar));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("Fin_d Themes",
                                                            ThemingMenuNames.FindThemesMenuItem,
                                                                ThemingMenuNames.MainMenu,
                                                            new DelegateCommand(themeFinder.FindThemes)));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("A_vailable Themes",
                                                            ThemingMenuNames.ThemeListMenuItem,
                                                                ThemingMenuNames.MainMenu));

            menuService.DisplayThisMenuItem(ThemingMenuNames.FindThemesMenuItem);
            menuService.DisplayThisMenuItem(ThemingMenuNames.ThemeListMenuItem);
        }
    }
}
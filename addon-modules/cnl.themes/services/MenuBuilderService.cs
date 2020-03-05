using System.Reflection;
using gsdc.toolbox.menubar;
using Prism.Commands;
using themes;

namespace cnl.themes.services
{
    internal class MenuBuilderService
    {
        public MenuBuilderService(IMenuInfoFactory infoFactory, IMenuService menuService, IThemeApplicationService themeApplicationService)
        {
            themeApplicationService.CreateThemeList(Assembly.GetAssembly(typeof(MenuBuilderService)));

            menuService.AddMenuItem(infoFactory.CreateMenuInfo("_CNL Themes",
                CnlThemeMenuItemNames.CnlThemes,
                ThemingMenuNames.ThemeListMenuItem));

            menuService.AddMenuItem(infoFactory.CreateMenuInfo("Bl_ack",
                CnlThemeMenuItemNames.CnlBlack,
                CnlThemeMenuItemNames.CnlThemes,
                new DelegateCommand(()=> themeApplicationService.ApplyTheme("Cnltheme_black"))));

            menuService.AddMenuItem(infoFactory.CreateMenuInfo("_Blue",
                CnlThemeMenuItemNames.CnlBlue,
                CnlThemeMenuItemNames.CnlThemes,
                new DelegateCommand(()=> themeApplicationService.ApplyTheme("Cnltheme_blue"))));

            menuService.AddMenuItem(infoFactory.CreateMenuInfo("_Silver",
                CnlThemeMenuItemNames.CnlSilver,
                CnlThemeMenuItemNames.CnlThemes,
                new DelegateCommand(()=> themeApplicationService.ApplyTheme("Cnltheme_silver"))));
        }
    }
}
using System.Reflection;
using gsdc.toolbox.menubar;
using Prism.Commands;
using themes;

namespace bureau.themes.services
{
    internal class MenuBuilderService
    {
        public MenuBuilderService(IMenuInfoFactory infoFactory, IMenuService menuService, IThemeApplicationService themeApplicationService)
        {
            themeApplicationService.CreateThemeList(Assembly.GetAssembly(typeof(MenuBuilderService)));
            
            menuService.AddMenuItem(infoFactory.CreateMenuInfo("_Bureau Themes",
                BureauThemeMenuItemNames.BureauThemes,
                ThemingMenuNames.ThemeListMenuItem));

            menuService.AddMenuItem(infoFactory.CreateMenuInfo("Bureau Bla_ck",
                BureauThemeMenuItemNames.BureauBlack,
                BureauThemeMenuItemNames.BureauThemes,
                new DelegateCommand(()=> themeApplicationService.ApplyTheme("Bureaublack"))));

            menuService.AddMenuItem(infoFactory.CreateMenuInfo("Bureau B_lue",
                BureauThemeMenuItemNames.BureauBlue,
                BureauThemeMenuItemNames.BureauThemes,
                new DelegateCommand(()=> themeApplicationService.ApplyTheme("Bureaublue"))));
        }
    }
}
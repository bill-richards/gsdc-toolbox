using System.Reflection;
using gsdc.toolbox.menubar;
using Prism.Commands;
using themes;

namespace bureau.themes.services
{
    internal class MenuBuilderService
    {
        public MenuBuilderService(IMenuInfoFactory infoFactory, IMenuRegistrar menuRegistrar, IThemeApplicationService themeApplicationService, IMenuService menuService)
        {
            themeApplicationService.CreateThemeList(Assembly.GetAssembly(typeof(MenuBuilderService)));
            
            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Bureau Themes",
                BureauThemeMenuItemNames.BureauThemes,
                ThemingMenuNames.ThemeListMenuItem));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("Bureau B_lue",
                BureauThemeMenuItemNames.BureauBlue,
                BureauThemeMenuItemNames.BureauThemes,
                new DelegateCommand(()=> themeApplicationService.ApplyTheme("Bureaublue"))));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("Bureau Bla_ck",
                BureauThemeMenuItemNames.BureauBlack,
                BureauThemeMenuItemNames.BureauThemes,
                new DelegateCommand(()=> themeApplicationService.ApplyTheme("Bureaublack"))));

            menuService.DisplayThisMenuItem(BureauThemeMenuItemNames.BureauBlue);
            menuService.DisplayThisMenuItem(BureauThemeMenuItemNames.BureauBlack);
        }
    }
}
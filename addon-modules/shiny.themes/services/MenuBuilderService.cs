using System.Reflection;
using gsdc.toolbox.menubar;
using Prism.Commands;
using themes;

namespace shiny.themes.services
{
    internal class MenuBuilderService
    {
        public MenuBuilderService(IMenuInfoFactory infoFactory, IMenuService menuService, IThemeApplicationService themeApplicationService)
        {
            themeApplicationService.CreateThemeList(Assembly.GetAssembly(typeof(MenuBuilderService)));
            
            menuService.AddMenuItem(infoFactory.CreateMenuInfo("_Shiny Themes",
                ShinyThemeMenuItemNames.ShinyThemes,
                ThemingMenuNames.ThemeListMenuItem));

            menuService.AddMenuItem(infoFactory.CreateMenuInfo("_Blue",
                ShinyThemeMenuItemNames.ShinyBlue,
                ShinyThemeMenuItemNames.ShinyThemes,
                new DelegateCommand(()=> themeApplicationService.ApplyTheme("Shinyblue"))));
            
            menuService.AddMenuItem(infoFactory.CreateMenuInfo("_Red",
                ShinyThemeMenuItemNames.ShinyRed,
                ShinyThemeMenuItemNames.ShinyThemes,
                new DelegateCommand(()=> themeApplicationService.ApplyTheme("Shinyred"))));
        }
    }
}
using System.Reflection;
using gsdc.toolbox.menubar;
using Prism.Commands;
using themes;

namespace shiny.themes.services
{
    internal class MenuBuilderService
    {
        public MenuBuilderService(IMenuInfoFactory infoFactory, IMenuRegistrar menuRegistrar, IThemeApplicationService themeApplicationService, IMenuService menuService)
        {
            themeApplicationService.CreateThemeList(Assembly.GetAssembly(typeof(MenuBuilderService)));
            
            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Shiny Themes",
                ShinyThemeMenuItemNames.ShinyThemes,
                ThemingMenuNames.ThemeListMenuItem));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Red",
                ShinyThemeMenuItemNames.ShinyRed,
                ShinyThemeMenuItemNames.ShinyThemes,
                new DelegateCommand(()=> themeApplicationService.ApplyTheme("Shinyred"))));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Blue",
                ShinyThemeMenuItemNames.ShinyBlue,
                ShinyThemeMenuItemNames.ShinyThemes,
                new DelegateCommand(()=> themeApplicationService.ApplyTheme("Shinyblue"))));

            menuService.DisplayThisMenuItem(ShinyThemeMenuItemNames.ShinyBlue);
            menuService.DisplayThisMenuItem(ShinyThemeMenuItemNames.ShinyRed);
        }
    }
}
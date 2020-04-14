using System.Reflection;
using gsdc.toolbox.menubar;
using Prism.Commands;
using themes;

namespace whistler.themes.services
{
    internal class MenuBuilderService
    {
        public MenuBuilderService(IMenuInfoFactory infoFactory, IMenuRegistrar menuRegistrar, IThemeApplicationService themeApplicationService, IMenuService menuService)
        {
            themeApplicationService.CreateThemeList(Assembly.GetAssembly(typeof(MenuBuilderService)));
            
            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Whistler Blue",
                WhistlerThemeMenuItemNames.WhistlerBlue,
                ThemingMenuNames.ThemeListMenuItem,
                new DelegateCommand(()=> themeApplicationService.ApplyTheme("Whistlerblue"))));

            menuService.DisplayThisMenuItem(WhistlerThemeMenuItemNames.WhistlerBlue);
        }
    }
}
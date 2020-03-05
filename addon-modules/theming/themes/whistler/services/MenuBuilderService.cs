using System.Reflection;
using gsdc.toolbox.menubar;
using Prism.Commands;
using themes;

namespace whistler.themes.services
{
    internal class MenuBuilderService
    {
        public MenuBuilderService(IMenuInfoFactory infoFactory, IMenuService menuService, IThemeApplicationService themeApplicationService)
        {
            themeApplicationService.CreateThemeList(Assembly.GetAssembly(typeof(MenuBuilderService)));
            
            menuService.AddMenuItem(infoFactory.CreateMenuInfo("_Whistler Blue",
                WhistlerThemeMenuItemNames.WhistlerBlue,
                ThemingMenuNames.ThemeListMenuItem,
                new DelegateCommand(()=> themeApplicationService.ApplyTheme("Whistlerblue"))));
        }
    }
}
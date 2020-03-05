using System.Reflection;
using gsdc.toolbox.menubar;
using Prism.Commands;
using themes;

namespace expression.themes.services
{
    internal class MenuBuilderService
    {
        public MenuBuilderService(IMenuInfoFactory infoFactory, IMenuService menuService, IThemeApplicationService themeApplicationService)
        {
            themeApplicationService.CreateThemeList(Assembly.GetAssembly(typeof(MenuBuilderService)));

            menuService.AddMenuItem(infoFactory.CreateMenuInfo("_Expression Themes",
                ExpressionThemeMenuItemNames.ExpressionThemes,
                ThemingMenuNames.ThemeListMenuItem));
            
            menuService.AddMenuItem(infoFactory.CreateMenuInfo("_Dark",
                ExpressionThemeMenuItemNames.ExpressionDark,
                ExpressionThemeMenuItemNames.ExpressionThemes,
                new DelegateCommand(()=> themeApplicationService.ApplyTheme("Expressiondark"))));

            menuService.AddMenuItem(infoFactory.CreateMenuInfo("_Light",
                ExpressionThemeMenuItemNames.ExpressionLight,
                ExpressionThemeMenuItemNames.ExpressionThemes,
                new DelegateCommand(()=> themeApplicationService.ApplyTheme("Expressionlight"))));
        }
    }
}
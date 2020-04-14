using System.Reflection;
using gsdc.toolbox.menubar;
using Prism.Commands;
using toolbox.themes;

namespace themes.expression.services
{
    internal class MenuBuilderService
    {
        public MenuBuilderService(IMenuInfoFactory infoFactory, IMenuRegistrar menuRegistrar, IThemeApplicationService themeApplicationService, IMenuService menuService)
        {
            themeApplicationService.CreateThemeList(Assembly.GetAssembly(typeof(MenuBuilderService)));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Expression Themes",
                ExpressionThemeMenuItemNames.ExpressionThemes,
                ThemingMenuNames.ThemeListMenuItem));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Light",
                ExpressionThemeMenuItemNames.ExpressionLight,
                ExpressionThemeMenuItemNames.ExpressionThemes,
                new DelegateCommand(()=> themeApplicationService.ApplyTheme("Expressionlight"))));
            
            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Dark",
                ExpressionThemeMenuItemNames.ExpressionDark,
                ExpressionThemeMenuItemNames.ExpressionThemes,
                new DelegateCommand(()=> themeApplicationService.ApplyTheme("Expressiondark"))));

            menuService.DisplayThisMenuItem(ExpressionThemeMenuItemNames.ExpressionLight);
            menuService.DisplayThisMenuItem(ExpressionThemeMenuItemNames.ExpressionDark);
        }
    }
}
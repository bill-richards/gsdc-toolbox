using System.Reflection;
using gsdc.toolbox.menubar;
using Prism.Commands;
using toolbox.themes;

namespace themes.expression.services
{
    internal class MenubarConstructionService
    {
        public MenubarConstructionService(IMenuInfoFactory infoFactory, IMenuRegistrar menuRegistrar, IThemeApplicationService themeApplicationService, IMenuService menuService)
        {
            themeApplicationService.CreateThemeList(Assembly.GetExecutingAssembly());

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Expression Themes",
                    ExpressionThemeMenuItemNames.ExpressionThemes,
                    ThemingMenuNames.ThemeListMenuItem)
                .And()
                .SetOwningModuleName(modules.ModuleDescription.ModuleName));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Light",
                    ExpressionThemeMenuItemNames.ExpressionLight,
                    ExpressionThemeMenuItemNames.ExpressionThemes,
                    new DelegateCommand(() => themeApplicationService.ApplyTheme("Expressionlight")))
                .And()
                .SetOwningModuleName(modules.ModuleDescription.ModuleName));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Dark",
                    ExpressionThemeMenuItemNames.ExpressionDark,
                    ExpressionThemeMenuItemNames.ExpressionThemes,
                    new DelegateCommand(() => themeApplicationService.ApplyTheme("Expressiondark")))
                .And()
                .SetOwningModuleName(modules.ModuleDescription.ModuleName));

            menuService.DisplayThisMenuItem(ExpressionThemeMenuItemNames.ExpressionLight);
            menuService.DisplayThisMenuItem(ExpressionThemeMenuItemNames.ExpressionDark);
        }
    }
}
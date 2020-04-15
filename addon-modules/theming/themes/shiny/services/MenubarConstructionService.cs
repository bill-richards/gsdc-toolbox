using System.Reflection;
using gsdc.toolbox.menubar;
using Prism.Commands;
using toolbox.themes;

namespace themes.shiny.services
{
    internal class MenubarConstructionService
    {
        public MenubarConstructionService(IMenuInfoFactory infoFactory, IMenuRegistrar menuRegistrar, IThemeApplicationService themeApplicationService, IMenuService menuService)
        {
            themeApplicationService.CreateThemeList(Assembly.GetExecutingAssembly());

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Shiny Themes",
                    ShinyThemeMenuItemNames.ShinyThemes,
                    ThemingMenuNames.ThemeListMenuItem)
                .And()
                .SetOwningModuleName(modules.ModuleDescription.ModuleName));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Red",
                    ShinyThemeMenuItemNames.ShinyRed,
                    ShinyThemeMenuItemNames.ShinyThemes,
                    new DelegateCommand(() => themeApplicationService.ApplyTheme("Shinyred")))
                .And()
                .SetOwningModuleName(modules.ModuleDescription.ModuleName));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Blue",
                    ShinyThemeMenuItemNames.ShinyBlue,
                    ShinyThemeMenuItemNames.ShinyThemes,
                    new DelegateCommand(() => themeApplicationService.ApplyTheme("Shinyblue")))
                .And()
                .SetOwningModuleName(modules.ModuleDescription.ModuleName));

            menuService.DisplayMenuItemsForModule(modules.ModuleDescription.ModuleName);
        }
    }
}
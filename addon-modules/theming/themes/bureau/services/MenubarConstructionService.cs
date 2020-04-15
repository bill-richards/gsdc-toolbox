using System.Reflection;
using gsdc.toolbox.menubar;
using Prism.Commands;
using toolbox.themes;

namespace themes.bureau.services
{
    internal class MenubarConstructionService
    {
        public MenubarConstructionService(IMenuInfoFactory infoFactory, IMenuRegistrar menuRegistrar, IThemeApplicationService themeApplicationService, IMenuService menuService)
        {
            themeApplicationService.CreateThemeList(Assembly.GetExecutingAssembly());

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Bureau Themes",
                    BureauThemeMenuItemNames.BureauThemes,
                    ThemingMenuNames.ThemeListMenuItem)
                .And()
                .SetOwningModuleName(modules.ModuleDescription.ModuleName));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("Bureau B_lue",
                    BureauThemeMenuItemNames.BureauBlue,
                    BureauThemeMenuItemNames.BureauThemes,
                    new DelegateCommand(() => themeApplicationService.ApplyTheme("Bureaublue")))
                .And()
                .SetOwningModuleName(modules.ModuleDescription.ModuleName));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("Bureau Bla_ck",
                    BureauThemeMenuItemNames.BureauBlack,
                    BureauThemeMenuItemNames.BureauThemes,
                    new DelegateCommand(() => themeApplicationService.ApplyTheme("Bureaublack")))
                .And()
                .SetOwningModuleName(modules.ModuleDescription.ModuleName));

            menuService.DisplayMenuItemsForModule(modules.ModuleDescription.ModuleName);
        }
    }
}
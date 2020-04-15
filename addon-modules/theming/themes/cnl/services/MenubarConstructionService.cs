using System.Reflection;
using gsdc.toolbox.menubar;
using Prism.Commands;
using toolbox.themes;

namespace themes.cnl.services
{
    internal class MenubarConstructionService
    {
        public MenubarConstructionService(IMenuInfoFactory infoFactory, IMenuRegistrar menuRegistrar, IThemeApplicationService themeApplicationService, IMenuService menuService)
        {
            themeApplicationService.CreateThemeList(Assembly.GetExecutingAssembly());

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_CNL Themes",
                    CnlThemeMenuItemNames.CnlThemes,
                    ThemingMenuNames.ThemeListMenuItem)
                .And()
                .SetOwningModuleName(modules.ModuleDescription.ModuleName));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("Bl_ack",
                    CnlThemeMenuItemNames.CnlBlack,
                    CnlThemeMenuItemNames.CnlThemes,
                    new DelegateCommand(() => themeApplicationService.ApplyTheme("Cnltheme_black")))
                .And()
                .SetOwningModuleName(modules.ModuleDescription.ModuleName));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Blue",
                    CnlThemeMenuItemNames.CnlBlue,
                    CnlThemeMenuItemNames.CnlThemes,
                    new DelegateCommand(() => themeApplicationService.ApplyTheme("Cnltheme_blue")))
                .And()
                .SetOwningModuleName(modules.ModuleDescription.ModuleName));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Silver",
                    CnlThemeMenuItemNames.CnlSilver,
                    CnlThemeMenuItemNames.CnlThemes,
                    new DelegateCommand(() => themeApplicationService.ApplyTheme("Cnltheme_silver")))
                .And()
                .SetOwningModuleName(modules.ModuleDescription.ModuleName));

            menuService.DisplayMenuItemsForModule(modules.ModuleDescription.ModuleName);
        }
    }
}
using gsdc.toolbox.menubar;
using Prism.Commands;

namespace toolbox.themes.services
{
    internal class MenubarConstructionService
    {
        public MenubarConstructionService(IMenuInfoFactory infoFactory, IMenuRegistrar menuRegistrar, IThemeFinderService themeFinder, IMenuService menuService)
        {
            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("T_heming",
                    ThemingMenuNames.MainMenu,
                    ToolboxMenuNames.ToolboxMenuBar)
                .And()
                .SetOwningModuleName(modules.ModuleDescription.ModuleName));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("Fin_d Themes",
                    ThemingMenuNames.FindThemesMenuItem,
                    ThemingMenuNames.MainMenu,
                    new DelegateCommand(themeFinder.FindThemes))
                .And()
                .SetOwningModuleName(modules.ModuleDescription.ModuleName));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("A_vailable Themes",
                    ThemingMenuNames.ThemeListMenuItem,
                    ThemingMenuNames.MainMenu)
                .And()
                .SetOwningModuleName(modules.ModuleDescription.ModuleName));

            menuService.DisplayMenuItemsForModule(modules.ModuleDescription.ModuleName);
        }
    }
}
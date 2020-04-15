using System.Reflection;
using gsdc.toolbox.menubar;
using Prism.Commands;
using toolbox.themes;

namespace themes.whistler.services
{
    internal class MenubarConstructionService
    {
        public MenubarConstructionService(IMenuInfoFactory infoFactory, IMenuRegistrar menuRegistrar, IThemeApplicationService themeApplicationService, IMenuService menuService)
        {
            themeApplicationService.CreateThemeList(Assembly.GetExecutingAssembly());

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Whistler Blue",
                    WhistlerThemeMenuItemNames.WhistlerBlue,
                    ThemingMenuNames.ThemeListMenuItem,
                    new DelegateCommand(() => themeApplicationService.ApplyTheme("Whistlerblue")))
                .And()
                .SetOwningModuleName(modules.ModuleDescription.ModuleName));

            menuService.DisplayMenuItemsForModule(modules.ModuleDescription.ModuleName);
        }
    }
}
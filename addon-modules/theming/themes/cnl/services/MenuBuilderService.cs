using System.Reflection;
using gsdc.toolbox.menubar;
using Prism.Commands;
using toolbox.themes;

namespace themes.cnl.services
{
    internal class MenuBuilderService
    {
        public MenuBuilderService(IMenuInfoFactory infoFactory, IMenuRegistrar menuRegistrar, IThemeApplicationService themeApplicationService)
        {
            themeApplicationService.CreateThemeList(Assembly.GetAssembly(typeof(MenuBuilderService)));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_CNL Themes",
                CnlThemeMenuItemNames.CnlThemes,
                ThemingMenuNames.ThemeListMenuItem));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("Bl_ack",
                CnlThemeMenuItemNames.CnlBlack,
                CnlThemeMenuItemNames.CnlThemes,
                new DelegateCommand(()=> themeApplicationService.ApplyTheme("Cnltheme_black"))));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Blue",
                CnlThemeMenuItemNames.CnlBlue,
                CnlThemeMenuItemNames.CnlThemes,
                new DelegateCommand(()=> themeApplicationService.ApplyTheme("Cnltheme_blue"))));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("_Silver",
                CnlThemeMenuItemNames.CnlSilver,
                CnlThemeMenuItemNames.CnlThemes,
                new DelegateCommand(()=> themeApplicationService.ApplyTheme("Cnltheme_silver"))));
        }
    }
}
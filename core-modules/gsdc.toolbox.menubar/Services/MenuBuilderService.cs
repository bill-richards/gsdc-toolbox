using gsdc.toolbox.events;
using gsdc.toolbox.menus;
using Prism.Commands;
using Prism.Events;

namespace gsdc.toolbox.menubar.Services
{
    internal class MenuBuilderService
    {
        public MenuBuilderService(IMenuInfoFactory infoFactory, IEventAggregator eventAggregator, IMenuService menuService)
        {
            menuService.AddMenuItem(infoFactory.CreateMenuInfo("T_oolbox",
                MenuNames.ToolboxMenu,
                MenuNames.ToolboxMenuBar));

            menuService.AddMenuItem(infoFactory.CreateMenuInfo("E_xit",
                "ExitButton",
                MenuNames.ToolboxMenu,
                new DelegateCommand(() => eventAggregator.GetEvent<ShutDownTheToolbox>().Publish(), () => true)));

            //menuService.AddMenuItem(infoFactory.CreateMenuSeparatorInfo(MenuNames.ToolboxMenu));
        }
    }
}
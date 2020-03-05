using gsdc.toolbox.events;
using gsdc.toolbox.menubar.Factories;
using Prism.Commands;
using Prism.Events;

namespace gsdc.toolbox.menubar.Services
{
    internal class MenuBarMenuBuilderService
    {
        public MenuBarMenuBuilderService(IMenuInfoFactory infoFactory, IEventAggregator eventAggregator, IMenuService menuService)
        {
            menuService.AddMenuItem(infoFactory.CreateMenuInfo("T_oolbox",
                ToolboxMenuNames.ToolboxMenu,
                ToolboxMenuNames.ToolboxMenuBar));

            menuService.AddMenuItem(infoFactory.CreateMenuInfo("E_xit",
                "ExitButton",
                ToolboxMenuNames.ToolboxMenu,
                new DelegateCommand(() => eventAggregator.GetEvent<ShutDownTheToolbox>().Publish(), () => true)));
        }
    }
}
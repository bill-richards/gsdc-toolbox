using gsdc.toolbox.events;
using Prism.Commands;
using Prism.Events;

namespace gsdc.toolbox.menubar.Services
{
    internal class MenuBarMenuBuilderService 
    {
        public MenuBarMenuBuilderService(IMenuInfoFactory infoFactory, IEventAggregator eventAggregator, IMenuRegistrar menuRegistrar, IMenuService menuService)
        {
            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("T_oolbox",
                ToolboxMenuNames.ToolboxMenu,
                ToolboxMenuNames.ToolboxMenuBar));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("E_xit",
                "ExitButton",
                ToolboxMenuNames.ToolboxMenu,
                new DelegateCommand(() => eventAggregator.GetEvent<ShutDownTheToolbox>().Publish(), () => true)));

            menuService.DisplayThisMenuItem("ExitButton");
        }
    }
}
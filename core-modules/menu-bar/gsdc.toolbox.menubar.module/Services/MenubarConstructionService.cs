﻿using gsdc.toolbox.events;
using gsdc.toolbox.menubar.modules;
using Prism.Commands;
using Prism.Events;

namespace gsdc.toolbox.menubar.Services
{
    internal class MenubarConstructionService 
    {
        public MenubarConstructionService(IMenuInfoFactory infoFactory, IEventAggregator eventAggregator, IMenuRegistrar menuRegistrar, IMenuService menuService)
        {
            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("T_oolbox",
                    ToolboxMenuNames.ToolboxMenu,
                    ToolboxMenuNames.ToolboxMenuBar)
                .And()
                .SetOwningModuleName(ModuleDescription.ModuleName));

            menuRegistrar.AddMenuItem(infoFactory.CreateMenuInfo("E_xit",
                    "ExitButton",
                    ToolboxMenuNames.ToolboxMenu,
                    new DelegateCommand(() => eventAggregator.GetEvent<ShutDownTheToolbox>().Publish(), () => true))
                .And()
                .SetOwningModuleName(ModuleDescription.ModuleName));

            menuService.DisplayMenuItemsForModule(ModuleDescription.ModuleName);
        }
    }
}
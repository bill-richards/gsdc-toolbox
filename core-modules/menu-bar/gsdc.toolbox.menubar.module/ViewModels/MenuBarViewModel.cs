using System.Collections.ObjectModel;
using gsdc.toolbox.menubar.Events;
using Prism.Mvvm;

namespace gsdc.toolbox.menubar.ViewModels
{
    internal class MenuBarViewModel : BindableBase
    {
        private readonly IMenuFacade _menuItemFacade;

        public MenuBarViewModel(IMenuFacade menuItemFacade, IMenuRegistrar menuRegistrar, IMenuServiceInterpreter menuServiceInterpreter, IMenuVisibilityEventPublisher menuVisibilityEventPublisher)
        {
            menuRegistrar.MenuItemAdded += MenuItemAdded;

            menuServiceInterpreter.DisplayAllMenus += () => menuVisibilityEventPublisher.SetVisibilityForAllMenuItems(true);
            menuServiceInterpreter.DisplayModuleMenus += moduleName => menuVisibilityEventPublisher.SetVisibilityForModuleMenuItems(moduleName, true);
            menuServiceInterpreter.DisplayThisMenu += menuName => menuVisibilityEventPublisher.SetVisibilityForSpecificMenuItem(menuName, true);

            menuServiceInterpreter.HideAllMenus += () => menuVisibilityEventPublisher.SetVisibilityForAllMenuItems(false);
            menuServiceInterpreter.HideModuleMenus += moduleName => menuVisibilityEventPublisher.SetVisibilityForModuleMenuItems(moduleName, false);
            menuServiceInterpreter.HideThisMenu += menuName => menuVisibilityEventPublisher.SetVisibilityForSpecificMenuItem(menuName, false);

            _menuItemFacade = menuItemFacade;
        }
        
        private void MenuItemAdded(IMenuInfo newMenuInfo)
        {
            if (newMenuInfo.ParentName != ToolboxMenuNames.ToolboxMenuBar) return;
            AddThisMenuItem(ref newMenuInfo);
        }

        public ObservableCollection<object> MenuItems { get; } = new ObservableCollection<object>();

        private void AddThisMenuItem(ref IMenuInfo info)
        {
            if (info.Name == ToolboxMenuNames.ToolboxMenuSeparator)
                MenuItems.Add(_menuItemFacade.CreateMenuSeparator());
            else
            {
                var vm = _menuItemFacade.CreateMenuViewModel(info);
                MenuItems.Add(_menuItemFacade.CreateMenuItemFromViewModel(vm));
            }
        }
    }
}

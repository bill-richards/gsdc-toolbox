using System.Collections.ObjectModel;
using System.Linq;
using Prism.Mvvm;

namespace gsdc.toolbox.menubar.ViewModels
{
    internal class MenuBarViewModel : BindableBase
    {
        private readonly IMenuItemFactory _menuItemFactory;
        private readonly IMenuItemViewModelFactory _menuItemViewModelFactory;

        public MenuBarViewModel(IMenuItemFactory menuItemFactory, IMenuService menuService, IMenuItemViewModelFactory menuItemViewModelFactory)
        {
            menuService.MenuItemAdded += MenuItemAdded;
            _menuItemFactory = menuItemFactory;
            _menuItemViewModelFactory = menuItemViewModelFactory;
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
                MenuItems.Add(_menuItemFactory.CreateSeparator());
            else
            {
                var vm = _menuItemViewModelFactory.CreateMenuViewModel(info);
                MenuItems.Add(_menuItemFactory.Create(vm));
            }
        }
    }
}

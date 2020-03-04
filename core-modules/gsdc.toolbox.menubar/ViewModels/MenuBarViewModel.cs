using System.Collections.ObjectModel;
using System.Linq;
using gsdc.toolbox.menus;
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
            if (newMenuInfo.ParentName != MenuNames.ToolboxMenuBar) return;

            var cache = MenuItems.ToList();
            MenuItems.Clear();
            AddThisMenuItem(ref newMenuInfo);
            MenuItems.AddRange(cache);
        }

        public ObservableCollection<object> MenuItems { get; } = new ObservableCollection<object>();

        private void AddThisMenuItem(ref IMenuInfo info)
        {
            if (info.Name == MenuNames.ToolboxMenuSeperator)
                MenuItems.Add(_menuItemFactory.CreateSeparator());
            else
            {
                var vm = _menuItemViewModelFactory.CreateMenuViewModel(info);
                MenuItems.Add(_menuItemFactory.Create(vm));
            }
        }
    }
}

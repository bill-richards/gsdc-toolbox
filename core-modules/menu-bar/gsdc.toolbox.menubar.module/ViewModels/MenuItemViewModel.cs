using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Prism.Mvvm;

namespace gsdc.toolbox.menubar.ViewModels
{
    internal class MenuItemViewModel : BindableBase, IMenuItemViewModel, IMenuItemViewModelFactory
    {
        private readonly IMenuItemFactory _menuItemFactory;
        private readonly IMenuService _menuService;

        public MenuItemViewModel(IMenuItemFactory menuItemFactory, IMenuService menuService)
        {
            _menuItemFactory = menuItemFactory;
            _menuService = menuService;
        }

        public IMenuItemViewModel CreateMenuViewModel(IMenuInfo menuInfo)
            => new MenuItemViewModel(menuInfo, _menuService, _menuItemFactory);

        private MenuItemViewModel(IMenuInfo info, IMenuService menuService, IMenuItemFactory menuItemFactory)
        {
            _menuService = menuService;
            _menuItemFactory = menuItemFactory;
            _menuService.MenuItemAdded += AddChildMenuItemIfIAmTheParent;

            MenuItems = new ObservableCollection<object>();
            Name = info.Name;
            Header = info.DisplayText;
            Command = info.Command;
            CommandParameter = info.CommandParameter;
            Icon = info.Icon;
            ToolTip = info.ToolTip;
        }

        private void AddChildMenuItemIfIAmTheParent(IMenuInfo newMenuInfo)
        {
            if (!newMenuInfo.ParentName.Equals(Name)) return;

            var cache = MenuItems.ToList();
            MenuItems.Clear();
            AddThisMenuItem(ref newMenuInfo);
            MenuItems.AddRange(cache);
        }

        private void AddThisMenuItem(ref IMenuInfo info)
        {
            if (info.Name == ToolboxMenuNames.ToolboxMenuSeparator)
                MenuItems.Add(_menuItemFactory.CreateSeparator());
            else
            {
                var vm = CreateMenuViewModel(info);
                MenuItems.Add(_menuItemFactory.Create(vm));
            }
        }

        public string Header { get; }
        public string Name { get; }
        public dynamic Icon { get; }
        public string ToolTip { get; }
        public ObservableCollection<object> MenuItems { get; }
        public ICommand Command { get; }
        public object CommandParameter { get; }
    }
}
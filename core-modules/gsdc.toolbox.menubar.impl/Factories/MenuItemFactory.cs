using System;
using System.Windows.Controls;

namespace gsdc.toolbox.menubar.Factories
{
    internal class MenuItemFactory : IMenuItemFactory
    {
        private readonly Func<MenuItem> _newMenuItem;
        private readonly Func<Separator> _newMenuSeparator;

        public MenuItemFactory(Func<MenuItem> menuItemFactoryMethod, Func<Separator> separatorFactory)
        {
            _newMenuItem = menuItemFactoryMethod;
            _newMenuSeparator = separatorFactory;
        }

        public MenuItem Create(IMenuItemViewModel vm)
        {
            var menuItem = _newMenuItem();

            menuItem.DataContext = vm;
            menuItem.Command = vm.Command;
            menuItem.CommandParameter = vm.CommandParameter;
            menuItem.Header = vm.Header;
            menuItem.Name = GetValidMenuNameFromGuid(vm.Name);
            menuItem.ItemsSource = vm.MenuItems;
            menuItem.Icon = vm.Icon;

            return menuItem;
        }
        public Separator CreateSeparator()
        {
            return _newMenuSeparator();
        }

        public string GetValidMenuNameFromGuid(string guid)
        {
            var name = guid.Replace("}", "").Replace("{", "").Replace("-", "");
            if (char.IsDigit(name[0])) name = $"_{name}";
            return name;
        }
    }
}
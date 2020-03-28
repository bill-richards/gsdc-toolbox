using System;

namespace gsdc.toolbox.menubar.Services
{
    internal class MenuService : IMenuService
    {
        public event Action<IMenuInfo> MenuItemAdded;

        public void AddMenuItem(IMenuInfo newMenu)
            => MenuItemAdded?.Invoke(newMenu);
    }
}
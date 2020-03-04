using System;

namespace gsdc.toolbox.menus
{
    public interface IMenuService
    {
        event Action<IMenuInfo> MenuItemAdded;

        void AddMenuItem(IMenuInfo newMenu);
    }
}
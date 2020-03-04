using System;
using gsdc.toolbox.menubar;

namespace gsdc.toolbox.menus
{
    public interface IMenuService
    {
        event Action<IMenuInfo> MenuItemAdded;

        void AddMenuItem(IMenuInfo newMenu);
    }
}
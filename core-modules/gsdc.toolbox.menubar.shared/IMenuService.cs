using System;

namespace gsdc.toolbox.menubar
{
    public interface IMenuService
    {
        event Action<IMenuInfo> MenuItemAdded;
        void AddMenuItem(IMenuInfo newMenu);
    }
}
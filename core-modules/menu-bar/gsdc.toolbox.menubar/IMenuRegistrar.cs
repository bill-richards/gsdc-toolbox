using System;

namespace gsdc.toolbox.menubar
{
    public interface IMenuRegistrar
    {
        event Action<IMenuInfo> MenuItemAdded;
        void AddMenuItem(IMenuInfo newMenu);
    }
}
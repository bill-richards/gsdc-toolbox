using System;

namespace gsdc.toolbox.menubar
{
    public interface IMenuService
    {
        void DisplayAllMenuItems();
        void HideAllMenuItems();
        void DisplayThisMenuItem(string menuName);
        void HideThisMenuItem(string menuName);
    }
}
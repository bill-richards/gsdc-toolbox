using System;

namespace gsdc.toolbox.menubar.ViewModels
{
    public class MenuService : IMenuServiceInterpreter, IMenuService
    {
        public event Action DisplayAllMenus;
        public event Action HideAllMenus;
        public event Action<string> DisplayThisMenu;
        public event Action<string> HideThisMenu;

        public void DisplayAllMenuItems()
            => DisplayAllMenus?.Invoke();

        public void HideAllMenuItems()
            => HideAllMenus?.Invoke();

        public void DisplayThisMenuItem(string menuName)
            => DisplayThisMenu?.Invoke(menuName);

        public void HideThisMenuItem(string menuName)
            => HideThisMenu?.Invoke(menuName);
    }
}
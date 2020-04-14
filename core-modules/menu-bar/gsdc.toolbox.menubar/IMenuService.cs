namespace gsdc.toolbox.menubar
{
    public interface IMenuService
    {
        void DisplayAllMenuItems();
        void DisplayMenuItemsForModule(string moduleName);
        void DisplayThisMenuItem(string menuName);
        void HideAllMenuItems();
        void HideMenuItemsForModule(string moduleName);
        void HideThisMenuItem(string menuName);
    }
}
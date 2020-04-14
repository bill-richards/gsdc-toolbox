namespace gsdc.toolbox.menubar.Events
{
    public interface IMenuVisibilityEventPublisher
    {
        void SetVisibilityForAllMenuItems(bool isVisible);
        void SetVisibilityForSpecificMenuItem(string menuItemName, bool isVisible);
    }
}
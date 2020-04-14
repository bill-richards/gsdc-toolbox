using System.Windows.Controls;

namespace gsdc.toolbox.menubar
{
    internal interface IMenuItemFactory
    {
        MenuItem CreateMenuItemFromViewModel(IMenuItemViewModel vm);
        Separator CreateMenuSeparator();
        string GetValidMenuNameFromGuid(string guid);
    }
}
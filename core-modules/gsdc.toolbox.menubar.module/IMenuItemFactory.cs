using System.Windows.Controls;

namespace gsdc.toolbox.menubar
{
    internal interface IMenuItemFactory
    {
        Separator CreateSeparator();
        MenuItem Create(IMenuItemViewModel vm);
        string GetValidMenuNameFromGuid(string guid);
    }
}
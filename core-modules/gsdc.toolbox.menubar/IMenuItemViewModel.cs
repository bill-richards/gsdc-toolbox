using System.Collections.ObjectModel;
using System.Windows.Input;

namespace gsdc.toolbox.menubar
{
    internal interface IMenuItemViewModel
    {
        string Header { get; }
        string Name { get; }

        ObservableCollection<object> MenuItems { get; }

        ICommand Command { get; }
        object CommandParameter { get; }
    }
}
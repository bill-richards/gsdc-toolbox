using System.Collections.ObjectModel;
using System.Windows.Input;

namespace gsdc.toolbox.menubar
{
    internal interface IMenuItemViewModel
    {
        string Header { get; }
        string Name { get; }

        dynamic Icon { get; }

        string ToolTip { get; }

        ObservableCollection<object> MenuItems { get; }

        ICommand Command { get; }
        object CommandParameter { get; }
    }
}
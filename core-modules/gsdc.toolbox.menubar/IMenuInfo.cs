using System.Windows.Input;

namespace gsdc.toolbox.menubar
{
    public interface IMenuInfo
    {
        ICommand Command { get; }
        object CommandParameter { get; }
        string DisplayText { get; }
        dynamic Icon { get; }
        string Name { get; }
        string ParentName { get; }
        string ToolTip { get; }
    }
}
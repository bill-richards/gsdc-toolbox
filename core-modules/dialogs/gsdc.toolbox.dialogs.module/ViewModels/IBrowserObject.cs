using System.Windows.Media;

namespace gsdc.toolbox.dialogs.ViewModels
{
    public interface IBrowserObject
    {
        string Name { get; }
        string Path { get; }
        ImageSource Image { get; }
    }
}
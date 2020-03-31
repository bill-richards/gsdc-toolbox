using System.ComponentModel;

namespace gsdc.toolbox.dialogs
{
    public interface IFolderBrowserService : INotifyPropertyChanged
    {
        string SelectedPath { get; set; }
    }
}
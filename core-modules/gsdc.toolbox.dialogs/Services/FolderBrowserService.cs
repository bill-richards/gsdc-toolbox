using Prism.Mvvm;

namespace gsdc.toolbox.dialogs.Views
{
    internal class FolderBrowserService : BindableBase, IFolderBrowserService
    {
        private bool _isDialogClosed;
        private string _selectedPath;

        public bool IsDialogClosed
        {
            get => _isDialogClosed;
            set => SetProperty(ref _isDialogClosed, value);
        }

        public string SelectedPath
        {
            get => _selectedPath;
            set => SetProperty(ref _selectedPath, value);
        }
    }
}
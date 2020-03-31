using Prism.Mvvm;

namespace gsdc.toolbox.dialogs.Services
{
    internal class FolderBrowserService : BindableBase, IFolderBrowserService, IDialogViewState
    {
        private bool _isDialogClosed;
        private string _selectedPath;

        public FolderBrowserService() 
            => IsDialogClosed = true;

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
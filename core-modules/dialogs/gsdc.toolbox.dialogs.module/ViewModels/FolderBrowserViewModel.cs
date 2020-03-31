using System.Windows.Input;
using gsdc.toolbox.dialogs.Services;
using Prism.Commands;
using Prism.Mvvm;

namespace gsdc.toolbox.dialogs.ViewModels
{
    internal class FolderBrowserViewModel : BindableBase
    {
        private string _selectedFolderPath;

        public FolderBrowserViewModel(IFolderBrowserService folderBrowserService, IDialogViewState viewState)
        {
            CancelCommand = new DelegateCommand<IClosable>(window =>
            {
                window?.Close();
                viewState.IsDialogClosed = true;
            });

            FolderSelectedCommand = new DelegateCommand<IClosable>(window =>
                {
                    window?.Close();
                    folderBrowserService.SelectedPath = _selectedFolderPath;
                    viewState.IsDialogClosed = true;
                });

            SelectedFolderPath = folderBrowserService.SelectedPath;
            viewState.IsDialogClosed = false;
        }

        public string SelectedFolderPath
        {
            get => _selectedFolderPath;
            set => SetProperty(ref _selectedFolderPath, value);
        }

        public ICommand FolderSelectedCommand { get; }
        public ICommand CancelCommand { get; }

        public string Title { get; } = "Please select a folder.";
    }
}
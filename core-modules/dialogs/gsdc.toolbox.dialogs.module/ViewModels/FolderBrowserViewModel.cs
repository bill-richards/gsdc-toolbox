using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace gsdc.toolbox.dialogs.ViewModels
{
    public class FolderBrowserViewModel : BindableBase
    {
        private string _selectedFolderPath;

        public FolderBrowserViewModel(IFolderBrowserService folderBrowserService)
        {
            CancelCommand = new DelegateCommand<IClosable>(window =>
            {
                window?.Close();
                folderBrowserService.IsDialogClosed = true;
            });

            FolderSelectedCommand = new DelegateCommand<IClosable>(window =>
                {
                    window?.Close();
                    folderBrowserService.SelectedPath = _selectedFolderPath;
                    folderBrowserService.IsDialogClosed = true;
                });

            SelectedFolderPath = folderBrowserService.SelectedPath;
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
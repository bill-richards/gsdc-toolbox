using System.Windows.Input;
using gsdc.toolbox.dialogs.Services;
using Prism.Commands;
using Prism.Mvvm;

namespace gsdc.toolbox.dialogs.ViewModels
{
    internal class SelectionViewModel : BindableBase
    {
        private string _selectedFolderPath;
        public SelectionViewModel(IFolderBrowserService folderBrowserService, IDialogViewState viewState)
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


            folderBrowserService.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(IFolderBrowserService.SelectedPath))
                    SelectedFolderPath = (sender as IFolderBrowserService).SelectedPath;
            };

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
    }
}
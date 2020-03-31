using System;
using gsdc.toolbox.dialogs.Services;
using gsdc.toolbox.dialogs.Views;

namespace gsdc.toolbox.dialogs.Factories
{
    internal class FolderBrowserFactory : IFolderBrowserFactory
    {
        private readonly Func<FolderBrowser> _folderBrowserFactoryMethod;
        private readonly IDialogViewState _folderBrowserService;

        public  FolderBrowserFactory(Func<FolderBrowser> folderBrowserFactoryMethod, IDialogViewState folderBrowserService)
        {
            _folderBrowserFactoryMethod = folderBrowserFactoryMethod;
            _folderBrowserService = folderBrowserService;
        }

        public void ShowFolderBrowser()
        {
            if (!_folderBrowserService.IsDialogClosed) return;
            _folderBrowserFactoryMethod().Show();
        }
    }
}
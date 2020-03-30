using System;

namespace gsdc.toolbox.dialogs.Views
{
    public class FolderBrowserFactory : IFolderBrowserFactory
    {
        private readonly Func<FolderBrowser> _folderBrowserFactoryMethod;
        private readonly IFolderBrowserService _folderBrowserService;

        public  FolderBrowserFactory(Func<FolderBrowser> folderBrowserFactoryMethod, IFolderBrowserService folderBrowserService)
        {
            _folderBrowserFactoryMethod = folderBrowserFactoryMethod;
            _folderBrowserService = folderBrowserService;
        }

        public void ShowFolderBrowser()
        {
            if (!_folderBrowserService.IsDialogClosed) return;

            _folderBrowserFactoryMethod().Show();
            _folderBrowserService.IsDialogClosed = false;
        }
    }
}
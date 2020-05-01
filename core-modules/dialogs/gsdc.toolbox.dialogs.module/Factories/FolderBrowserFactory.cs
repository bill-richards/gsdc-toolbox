using System;
using gsdc.toolbox.dialogs.Services;
using gsdc.toolbox.dialogs.Views;
using Prism.Regions;

namespace gsdc.toolbox.dialogs.Factories
{
    internal class FolderBrowserFactory : IFolderBrowserFactory
    {
        private readonly Func<FolderBrowser> _folderBrowserFactoryMethod;
        private readonly IDialogViewState _folderBrowserViewState;
        private readonly IRegionManager _regionManager;

        public  FolderBrowserFactory(Func<FolderBrowser> folderBrowserFactoryMethod, IDialogViewState folderBrowserViewState, IRegionManager regionManager)
        {
            _folderBrowserFactoryMethod = folderBrowserFactoryMethod;
            _folderBrowserViewState = folderBrowserViewState;
            _regionManager = regionManager;
        }

        public void ShowFolderBrowser()
        {
            if (!_folderBrowserViewState.IsDialogClosed) return;
            _regionManager.RegisterViewWithRegion(RegionNames.FolderBrowserSelectionRegion, typeof(Selection));
            _regionManager.RegisterViewWithRegion(RegionNames.FolderBrowserTreeViewRegion, typeof(SelectionTree));
            _regionManager.RegisterViewWithRegion(RegionNames.FolderBrowserFolderViewRegion, typeof(FolderDetail));

            _folderBrowserFactoryMethod().ShowDialog();
        }
    }
}
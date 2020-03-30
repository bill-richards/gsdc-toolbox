using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using gsdc.toolbox.dialogs.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace gsdc.toolbox.addons.ViewModels
{
    public class AddOnModuleLoaderViewModel : BindableBase
    {
        private readonly IFolderBrowserService _folderBrowserService;
        private string _path;

        public AddOnModuleLoaderViewModel(IRegionManager regionManager, IApplicationService applicationService, IFolderBrowserFactory folderBrowserFactory, IFolderBrowserService folderBrowserService)
        {
            _folderBrowserService = folderBrowserService;
            AllDoneHereCommand = new DelegateCommand(() =>
            {
                var region = regionManager.Regions[RegionNames.ShellTopRegion];
                var view = region.Views.First();
                region.Deactivate(view);
                region.Remove(view);
            });

            _folderBrowserService.PropertyChanged += BrowserServicePropertyChanged;

            PathFinderCommand = new DelegateCommand(folderBrowserFactory.ShowFolderBrowser);
        }

        private void BrowserServicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(_folderBrowserService.SelectedPath)) return;
            RaisePropertyChanged(nameof(Path));
        }

        public ICommand AllDoneHereCommand { get; }

        public ICommand PathFinderCommand { get; }

        public string Label { get; } = "Directory";
        public string LoadLabel { get; } = "Load Module";
        public string AllDoneLabel { get; } = "Finished";

        public string Path
        {
            get => _folderBrowserService.SelectedPath;
            set => _folderBrowserService.SelectedPath = value;
        }
    }
}

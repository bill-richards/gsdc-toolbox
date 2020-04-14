using System.Windows.Input;
using gsdc.toolbox.addons.Views;
using Prism.Commands;
using Prism.Regions;

namespace gsdc.toolbox.addons.services
{
    internal class AddOnsMenuCommands : IAddOnsMenuCommands
    {
        public AddOnsMenuCommands(IRegionManager regionManager, IAddOnService addOnService, IApplicationService applicationService)
        {
            LoadAddOnModuleCommand = new DelegateCommand(() =>
                regionManager.RegisterViewWithRegion(RegionNames.ShellTopRegion, typeof(AddOnModuleLoaderView)));

            LoadApplicationAddOnModulesCommand =
                new DelegateCommand(() => addOnService.LoadAddOns(applicationService.AddOnsDirectory));
        }

        public ICommand LoadAddOnModuleCommand { get; }
        public ICommand LoadApplicationAddOnModulesCommand { get; }
    }
}
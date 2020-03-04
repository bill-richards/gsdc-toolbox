using gsdc.toolbox.modules.background.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace gsdc.toolbox.modules.background
{
    public class BackgroundModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();

            regionManager.RegisterViewWithRegion(RegionNames.ShellBackgroundRegion, typeof(Background));
            regionManager.RegisterViewWithRegion(BackgroundRegionNames.BannerRegion, typeof(Banner));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
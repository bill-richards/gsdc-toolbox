using gsdc.toolbox.dialogs.Factories;
using gsdc.toolbox.dialogs.Services;
using Prism.Ioc;
using Prism.Modularity;

namespace gsdc.toolbox.dialogs.Modules
{
    public class DialogsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var browserService = containerProvider.Resolve<IFolderBrowserService>();
            browserService.IsDialogClosed = true;
            browserService.SelectedPath = containerProvider.Resolve<IApplicationService>().AddOnsDirectory;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IFolderBrowserService, FolderBrowserService>();
            containerRegistry.RegisterSingleton<IFolderBrowserFactory, FolderBrowserFactory>();
        }
    }
}
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
            containerProvider.Resolve<IFolderBrowserService>().SelectedPath = containerProvider.Resolve<IApplicationService>().AddOnsDirectory;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IDialogViewState, FolderBrowserService>();
            containerRegistry.RegisterSingleton<IFolderBrowserService, FolderBrowserService>();
            containerRegistry.RegisterSingleton<IFolderBrowserFactory, FolderBrowserFactory>();
        }
    }
}
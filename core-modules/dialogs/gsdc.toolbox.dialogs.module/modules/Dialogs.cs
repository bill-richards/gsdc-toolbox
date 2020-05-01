using gsdc.toolbox.dialogs.Factories;
using gsdc.toolbox.dialogs.Services;
using gsdc.toolbox.dialogs.ViewModels;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace gsdc.toolbox.dialogs.modules
{
    [Module(ModuleName = ModuleDescription.ModuleName)]
    public class Dialogs : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            containerProvider.Resolve<IFolderBrowserService>().SelectedPath = containerProvider.Resolve<IApplicationService>().AddOnsDirectory;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IRootFactory, Root>();
            containerRegistry.RegisterSingleton<IDriveFactory, Drive>();
            containerRegistry.RegisterSingleton<IFolderFactory, Folder>();

            containerRegistry.RegisterSingleton<IDialogViewState, FolderBrowserService>();
            containerRegistry.RegisterSingleton<IFolderBrowserService, FolderBrowserService>();
            containerRegistry.RegisterSingleton<IFolderBrowserFactory, FolderBrowserFactory>();
        }
    }
}
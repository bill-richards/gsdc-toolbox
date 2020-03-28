using System.IO;
using Prism.Ioc;
using gsdc.toolbox.Views;
using System.Windows;
using gsdc.toolbox.commands;
using Prism.Modularity;

namespace gsdc.toolbox
{
    public partial class App
    {
        protected override Window CreateShell() 
            => Container.Resolve<MainWindow>();

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IToolboxApplicationCommands, ToolboxApplicationCommands>();
            containerRegistry.RegisterSingleton<IApplicationService, ApplicationService>();
        }

        protected override IModuleCatalog CreateModuleCatalog() 
            => new DirectoryModuleCatalog() { ModulePath = Directory.GetCurrentDirectory() };
    }
}

using Prism.Ioc;
using Prism.Modularity;
using ThemeChanger.Services;

namespace ThemeChanger
{
    public class ThemeChanger : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            containerProvider.Resolve<MenuBuilderService>();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<MenuBuilderService>();
        }
    }
}
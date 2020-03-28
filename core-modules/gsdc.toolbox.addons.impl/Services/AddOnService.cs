namespace gsdc.toolbox.addons.services
{
    internal class AddOnService : IAddOnService
    {
        private readonly IModuleLoader _moduleLoader;

        public AddOnService(IModuleLoader moduleLoader) 
            => _moduleLoader = moduleLoader;

        public void LoadAddOns(string directory) 
            => _moduleLoader.ScanAndLoadModules(directory);
    }
}
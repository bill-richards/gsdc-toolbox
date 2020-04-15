using System.IO;

namespace gsdc.toolbox.addons.services
{
    internal class AddOnService : IAddOnService
    {
        private readonly IModuleLoader _moduleLoader;

        public AddOnService(IModuleLoader moduleLoader) 
            => _moduleLoader = moduleLoader;

        public void LoadAddOns(string path)
        {
            FileAttributes fileAttributes;
            try { fileAttributes = File.GetAttributes(path); }
            catch { return; }

            if (fileAttributes.HasFlag(FileAttributes.Directory))
                _moduleLoader.ScanAndLoadModules(in path);
            else
                _moduleLoader.LoadModule(in path);
        }
    }
}
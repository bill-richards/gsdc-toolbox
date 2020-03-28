namespace gsdc.toolbox
{
    public interface IModuleLoader
    {
        void ScanAndLoadModules(string path, bool doNotScanImmediateChildDirectories = false);
    }
}
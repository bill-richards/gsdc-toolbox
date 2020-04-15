using System.Collections.Generic;
using Prism.Modularity;

namespace gsdc.toolbox
{
    public interface IModuleLoader
    {
        IEnumerable<IModuleInfo> ModulesWithMissingDependencies { get; }

        int LoadModule(in string filePath);
        int ScanAndLoadModules(in string path, bool doNotScanChildDirectories = false);
    }
}
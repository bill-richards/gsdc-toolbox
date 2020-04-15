using System.Collections.Generic;
using Prism.Modularity;

namespace gsdc.toolbox.module.loader.services
{
    internal interface IModuleLocator
    {
        IEnumerable<IModuleInfo> ParseDirectoriesForModulesToLoad(in string path, bool scanChildDirectories = true);
    }
}
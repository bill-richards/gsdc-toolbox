using System;
using System.Collections.Generic;
using System.IO;
using Prism.Modularity;

namespace gsdc.toolbox.module.loader.factories
{
    internal interface IModuleInfoFactory
    {
        IModuleInfo CreateModuleInfo(Type type);
        IEnumerable<IModuleInfo> GetModuleInfos(in DirectoryInfo directory, Type moduleType);
    }
}
using System;
using Prism.Ioc;

namespace gsdc.toolbox.viewactivator
{
    public interface ICloseViewInfo
    {
        Type ViewInterfaceType { get; }
        string ViewName { get; }
    }
}
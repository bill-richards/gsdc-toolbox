using System;

namespace gsdc.toolbox.viewactivator
{
    public interface IViewInfo<out TViewType> : IViewInfo
    {
        new TViewType View { get; }
    }

    public interface IViewInfo
    {
        object View { get; }
        string ViewName { get; }
        Type ViewInterfaceType { get; }
        bool RemoveExistingViews { get; }
        string RegisteredRegion { get; }
    }
}
using System;

namespace gsdc.toolbox.viewactivator
{
    internal class ViewInfo<TViewType> : IViewInfo<TViewType>
    {
        public ViewInfo(TViewType view, string name, string region, bool removeExisting = false)
        {
            View = view;
            ViewInterfaceType = typeof(TViewType);
            RemoveExistingViews = removeExisting;
            ViewName = string.IsNullOrEmpty(name) ? ViewInterfaceType.Name : name;
            RegisteredRegion = region;
        }

        public TViewType View { get; }
        public Type ViewInterfaceType { get; }

        object IViewInfo.View => View;

        public string ViewName { get; }
        public bool RemoveExistingViews { get; }

        public string RegisteredRegion { get; }
    }
}
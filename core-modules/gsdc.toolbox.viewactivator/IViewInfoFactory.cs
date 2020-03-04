namespace gsdc.toolbox.viewactivator
{
    internal interface IViewInfoFactory
    {
        IViewInfo<TViewInterface> CreateInfo<TViewInterface>(TViewInterface view, bool removeExistingViews = false, string name = "", string rgisterdRegion = "");
    }
}
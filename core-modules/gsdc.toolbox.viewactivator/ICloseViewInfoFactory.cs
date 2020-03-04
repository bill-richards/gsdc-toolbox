namespace gsdc.toolbox.viewactivator
{
    internal interface ICloseViewInfoFactory
    {
        ICloseViewInfo CreateInfo<TViewInterface>();
    }
}
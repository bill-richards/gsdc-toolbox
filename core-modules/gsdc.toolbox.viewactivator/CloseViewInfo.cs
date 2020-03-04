using System;

namespace gsdc.toolbox.viewactivator
{
    internal class CloseViewInfo : ICloseViewInfo
    {
        public CloseViewInfo(Type viewInterfaceType)
        {
            ViewInterfaceType = viewInterfaceType;
        }

        public Type ViewInterfaceType { get; } 

        public string ViewName
            => ViewInterfaceType.Name;
    }
}
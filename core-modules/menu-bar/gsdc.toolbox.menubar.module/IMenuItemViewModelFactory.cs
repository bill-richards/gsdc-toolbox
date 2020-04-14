
using System;

namespace gsdc.toolbox.menubar
{
    internal interface IMenuItemViewModelFactory
    {
        Func<IMenuInfo,IMenuItemViewModel> CreateMenuViewModel { get; } 
    }
}
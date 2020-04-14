using System;
using System.Windows.Controls;

namespace gsdc.toolbox.menubar
{
    internal interface IMenuFacade
    {
        Func<IMenuItemViewModel,MenuItem> CreateMenuItemFromViewModel { get; }
        Func<Separator> CreateMenuSeparator { get; }
        Func<IMenuInfo, IMenuItemViewModel> CreateMenuViewModel { get; } 
        Func<string, string> GetValidMenuNameFromGuid { get; } 
    }
}
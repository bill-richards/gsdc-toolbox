﻿using System.Windows.Input;

namespace gsdc.toolbox.menus
{
    public interface IMenuInfoFactory
    {
        IMenuInfo CreateMenuInfo(string displayText, string name, string parentMenuName = "", ICommand command = null, dynamic commandParameter = null);

        IMenuInfo CreateMenuSeparatorInfo(string parentMenuName);
    }
}
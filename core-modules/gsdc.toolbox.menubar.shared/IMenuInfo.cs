﻿using System.Windows.Input;

namespace gsdc.toolbox.menubar
{
    public interface IMenuInfo
    {
        string DisplayText { get; }
        string Name { get; }
        string ParentName { get; }
        ICommand Command { get; }
        object CommandParameter { get; }
    }
}
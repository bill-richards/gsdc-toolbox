﻿namespace gsdc.toolbox.menubar.Events
{
    public interface IMenuVisibilityEventArgs
    {
        string AllMenuItems { get; }
        bool IsMenuVisible { get; }
        string MenuName { get; }
    }
}
﻿using System.ComponentModel;

namespace gsdc.toolbox.dialogs.Views
{
    public interface IFolderBrowserService : INotifyPropertyChanged
    {
        bool IsDialogClosed { get; set; }
        string SelectedPath { get; set; }
    }

}
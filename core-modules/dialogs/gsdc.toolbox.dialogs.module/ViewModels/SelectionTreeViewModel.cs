using System;
using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace gsdc.toolbox.dialogs.ViewModels
{
    public class SelectionTreeViewModel : BindableBase
    {
        public SelectionTreeViewModel(IRootFactory rootFactory)
        {
            LocationRoots.Add(rootFactory.Create($"Local Machine ({Environment.MachineName})"));
            LocationRoots.Add(rootFactory.Create("Network Drives", false));
        }

        public ObservableCollection<IBrowserObject> LocationRoots { get; } = new ObservableCollection<IBrowserObject>();
    }
}

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using gsdc.toolbox.menubar.Events;
using Prism.Mvvm;

namespace gsdc.toolbox.menubar.ViewModels
{
    internal class MenuItemViewModel : BindableBase, IMenuItemViewModel, IMenuItemViewModelFactory
    {
        private readonly IMenuItemFactory _menuItemFactory;
        private readonly IMenuVisibilityEventFacade _menuVisibilityEventFacade;
        private Visibility _visibility;

        public MenuItemViewModel(IMenuItemFactory menuItemFactory, IMenuRegistrar menuRegistrar, IMenuVisibilityEventFacade menuVisibilityEventFacade) 
            => CreateMenuViewModel = menuInfo => new MenuItemViewModel(menuInfo, menuRegistrar, menuItemFactory, menuVisibilityEventFacade, CreateMenuViewModel);

        public Func<IMenuInfo, IMenuItemViewModel> CreateMenuViewModel { get; } 

        private MenuItemViewModel(IMenuInfo info, IMenuRegistrar menuRegistrar, IMenuItemFactory menuItemFactory, IMenuVisibilityEventFacade menuVisibilityEventFacade, Func<IMenuInfo, IMenuItemViewModel> factoryFunc)
        {
            _menuItemFactory = menuItemFactory;
            _menuVisibilityEventFacade = menuVisibilityEventFacade;
            CreateMenuViewModel = factoryFunc;

            MenuItems = new ObservableCollection<object>();
            Name = info.Name;
            Header = info.DisplayText;
            Command = info.Command;
            CommandParameter = info.CommandParameter;
            Icon = info.Icon;
            ParentName = info.ParentName;
            ToolTip = info.ToolTip;
            Visibility = Visibility.Collapsed;
            OwningModuleName = info.OwningModuleName;

            _menuVisibilityEventFacade.SetEventSubscription(SetVisibility, ShouldSetMenuVisibility);
            menuRegistrar.MenuItemAdded += AddChildMenuItemIfIAmTheParent;
        }

        private bool ShouldSetMenuVisibility(IMenuVisibilityEventArgs args)
            => (!string.IsNullOrWhiteSpace(args.MenuName) && (args.MenuName.Equals(Name) || args.MenuName.Equals(args.AllMenuItems)) 
                || !string.IsNullOrWhiteSpace(args.OwningModuleName) || args.OwningModuleName == OwningModuleName)
               && args.IsMenuVisible != IsVisible;

        private bool IsVisible => Visibility == Visibility.Visible;

        private void AddChildMenuItemIfIAmTheParent(IMenuInfo newMenuInfo)
        {
            if (!newMenuInfo.ParentName.Equals(Name)) return;

            var list = MenuItems.ToList();
            MenuItems.Clear();
            AddThisMenuItem(ref newMenuInfo);
            MenuItems.AddRange(list);
        }

        private void AddThisMenuItem(ref IMenuInfo info)
        {
            if (info.Name == ToolboxMenuNames.ToolboxMenuSeparator)
            {
                MenuItems.Add(_menuItemFactory.CreateMenuSeparator());
                return;
            }

            var menuItemViewModel = CreateMenuViewModel(info);
            MenuItems.Add(_menuItemFactory.CreateMenuItemFromViewModel(menuItemViewModel));
        }

        public string Header { get; }
        public string Name { get; }
        public dynamic Icon { get; }
        public string ToolTip { get; }
        
        public string ParentName { get; }

        public Visibility Visibility
        {
            get => _visibility;
            private set => SetProperty(ref _visibility, value);
        }

        private void SetVisibility(IMenuVisibilityEventArgs eventArgs)
        {
            Visibility = eventArgs.IsMenuVisible ? Visibility.Visible : Visibility.Collapsed;
            _menuVisibilityEventFacade.SetVisibilityForSpecificMenuItem(ParentName, eventArgs.IsMenuVisible);
        }

        public ObservableCollection<object> MenuItems { get; }

        private string OwningModuleName { get; }

        public ICommand Command { get; }
        public object CommandParameter { get; }
    }
}
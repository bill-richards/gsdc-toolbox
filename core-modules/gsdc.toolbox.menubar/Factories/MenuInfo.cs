using System.Windows.Input;
using gsdc.toolbox.menus;

namespace gsdc.toolbox.menubar.Factories
{
    internal class MenuInfo : IMenuInfo, IMenuInfoFactory
    {
        public MenuInfo() { }

        private MenuInfo(string text, string name, string parentName, ICommand command = null, object commandParameter = null)
        {
            DisplayText = text;
            Name = name;
            ParentName = parentName;
            Command = command;
            CommandParameter = commandParameter;
        }

        public string DisplayText { get; }
        public string Name { get; }
        public string ParentName { get; }
        public ICommand Command { get; }
        public object CommandParameter { get; }

        public IMenuInfo CreateMenuInfo(string displayText, string name, string parentMenuName = "", ICommand command = null, dynamic commandParameter = null)
            => new MenuInfo(displayText, name, parentMenuName, command, commandParameter);

        public IMenuInfo CreateMenuSeparatorInfo(string parentMenuName)
            => new MenuInfo(string.Empty, MenuNames.ToolboxMenuSeperator, parentMenuName);
    }
}
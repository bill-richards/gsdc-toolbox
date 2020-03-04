using System.Windows.Input;

namespace gsdc.toolbox.menus
{
    public interface IMenuInfoFactory
    {
        IMenuInfo CreateMenuInfo(string name, string displayText, string parentMenuName = "", ICommand command = null, dynamic commandParameter = null);

        IMenuInfo CreateMenuSeparatorInfo(string parentMenuName);
    }
}
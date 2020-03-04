using gsdc.toolbox.menus;

namespace gsdc.toolbox.menubar
{
    internal interface IMenuItemViewModelFactory
    {
        IMenuItemViewModel CreateMenuViewModel(IMenuInfo menuInfo);
    }
}
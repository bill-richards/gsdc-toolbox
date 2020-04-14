using System;

namespace gsdc.toolbox.menubar
{
    public interface IMenuServiceInterpreter
    {
        event Action DisplayAllMenus;
        event Action HideAllMenus;
        event Action<string> DisplayThisMenu;
        event Action<string> HideThisMenu;
    }
}
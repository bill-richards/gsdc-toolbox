using System.Windows.Input;

namespace gsdc.toolbox.addons.services
{
    internal interface IAddOnsMenuCommands
    {
        ICommand LoadAddOnModuleCommand { get; }
        ICommand LoadApplicationAddOnModulesCommand { get; }
    }
}
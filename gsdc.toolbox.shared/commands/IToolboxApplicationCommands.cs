using Prism.Commands;

namespace gsdc.toolbox.commands
{
    public interface IToolboxApplicationCommands
    {
        CompositeCommand CloseApplicationGracefully { get; }   
    }
}
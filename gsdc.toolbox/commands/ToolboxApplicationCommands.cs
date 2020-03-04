using Prism.Commands;

namespace gsdc.toolbox.commands
{
    internal class ToolboxApplicationCommands : IToolboxApplicationCommands
    {
        public CompositeCommand CloseApplicationGracefully { get; } = new CompositeCommand();
    }
}
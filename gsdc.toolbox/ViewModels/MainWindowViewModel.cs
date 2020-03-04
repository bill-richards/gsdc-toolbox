using System.ComponentModel;
using gsdc.toolbox.commands;
using gsdc.toolbox.events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace gsdc.toolbox.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IToolboxApplicationCommands _applicationCommands;
        private string _title = "gsdc Toolbox";

        public MainWindowViewModel(IEventAggregator eventAggregator, IToolboxApplicationCommands applicationCommands)
        {
            _applicationCommands = applicationCommands;
            CloseApplicationGracefully = new DelegateCommand(() => System.Windows.Application.Current.Shutdown());
            _applicationCommands.CloseApplicationGracefully.RegisterCommand(CloseApplicationGracefully);

            eventAggregator.GetEvent<ShutDownTheToolbox>().Subscribe(AppExit, ThreadOption.UIThread);
        }

        private DelegateCommand CloseApplicationGracefully { get; }

        private void AppExit()
        {
            var e = new CancelEventArgs();
            if (_applicationCommands.CloseApplicationGracefully.CanExecute(e))
                _applicationCommands.CloseApplicationGracefully.Execute(e);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
    }
}

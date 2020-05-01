namespace gsdc.toolbox.dialogs.ViewModels
{
    public interface IRootFactory
    {
        public IBrowserObject Create(string name, bool localDrivesOnly = true);
    }
}
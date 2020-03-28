namespace gsdc.toolbox
{
    public interface IApplicationService
    {
        string AddOnsDirectory { get; }
        string AddOnsDirectoryName { get; }
        string CoreModulesDirectory { get; }

        string GetRootPath();
        string GetSubDirectory(params string[] directories);
    }
}
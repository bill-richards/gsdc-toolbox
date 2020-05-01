using System.IO;

namespace gsdc.toolbox.dialogs.ViewModels
{
    public interface IFolderFactory
    {
        IBrowserObject Create(DirectoryInfo info, bool asynchronously = true);
    }
}
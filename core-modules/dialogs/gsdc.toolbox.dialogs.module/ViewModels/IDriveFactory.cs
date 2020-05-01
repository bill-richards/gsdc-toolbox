using System.IO;

namespace gsdc.toolbox.dialogs.ViewModels
{
    public interface IDriveFactory
    {
        IBrowserObject Create(DriveInfo info);
    }
}
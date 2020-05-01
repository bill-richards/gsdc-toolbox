using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Windows.Threading;
using Prism.Mvvm;

namespace gsdc.toolbox.dialogs.ViewModels
{
    public class Drive : BindableBase, IDriveFactory, IBrowserObject
    {
        private readonly IFolderFactory _folderFactory;

        public Drive(IFolderFactory folderFactory) => _folderFactory = folderFactory;

        private Drive(IFolderFactory folderFactory, DriveInfo info)
        {
            _folderFactory = folderFactory;
            Name = $"{info.VolumeLabel} ({info.RootDirectory})";

            ListDriveFolders(info);
        }

        private void ListDriveFolders(DriveInfo info)
        {
            var paths = Directory.GetDirectories(info.RootDirectory.Root.Name);

            foreach (var path in paths)
            {
                try
                {
                    var dir = new DirectoryInfo(path);
                    if (dir.Attributes.HasFlag(FileAttributes.Hidden) ||
                        dir.Attributes.HasFlag(FileAttributes.System)) continue;

                    var folder = _folderFactory.Create(dir);
                    if (!string.IsNullOrWhiteSpace(folder.Name) && Folders.All(f => f.Name != folder.Name))
                        Dispatcher.CurrentDispatcher.InvokeAsync(() => Folders.Add(folder));
                }
                catch
                {
                    continue;
                }
            }
        }

        public ImageSource Image { get; set; }

        public string Name { get; set; }
        public string Path { get; set; }
        public ObservableCollection<IBrowserObject> Folders { get; set; } = new ObservableCollection<IBrowserObject>();

        public IBrowserObject Create(DriveInfo info) => new Drive(_folderFactory, info);
    }
}
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Media;
using Prism.Mvvm;

namespace gsdc.toolbox.dialogs.ViewModels
{
    public class Root : BindableBase, IRootFactory, IBrowserObject
    {
        private readonly IDriveFactory _driveFactory;
        private string _name;

        public Root(IDriveFactory driveFactory)
            => _driveFactory = driveFactory;

        private Root(IDriveFactory driveFactory, string name, bool showLocalOnly = true)
        {
            _driveFactory = driveFactory;
            Name = name;

            Drives.AddRange(showLocalOnly
                ? DriveInfo.GetDrives().Where(info => info.DriveType == DriveType.Fixed)
                    .Select(info => _driveFactory.Create(info))
                : DriveInfo.GetDrives().Where(info => info.DriveType == DriveType.Network)
                    .Select(info => _driveFactory.Create(info)));
        }

        public string Name
        {
            get => _name;
            private set => SetProperty(ref _name, value);
        }
        public string Path { get; }

        public ImageSource Image { get; }

        public ObservableCollection<IBrowserObject> Drives { get; set; } = new ObservableCollection<IBrowserObject>();

        public IBrowserObject Create(string name, bool localDrivesOnly = true) 
            => new Root(_driveFactory, name, localDrivesOnly);
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;
using Prism.Mvvm;

namespace gsdc.toolbox.dialogs.ViewModels
{
    public class Folder : BindableBase, IFolderFactory, IBrowserObject
    {
        private readonly Func<IFolderFactory> _folderFactoryMethod;

        public Folder(Func<IFolderFactory> folderFactoryMethod) => _folderFactoryMethod = folderFactoryMethod;

        private Folder(Func<IFolderFactory> folderFactoryMethod, DirectoryInfo info, bool asynchronously)
        {
            _folderFactoryMethod = folderFactoryMethod;
            Name = info.Name;
            Path = info.FullName;

            try { var directories = info.GetDirectories(); }
            catch
            {
                Name = string.Empty;
                Path = string.Empty;
                return;
            }

            SetFolders(info, asynchronously);
        }

        private async void SetFolders(DirectoryInfo info, bool asynchronously)
        {
            List<IBrowserObject> folders;

            if(asynchronously)
                folders = await GetFoldersAsync(info, _folderFactoryMethod);
            else
                folders = GetFolders(info, _folderFactoryMethod);

            Dispatcher.CurrentDispatcher.InvokeAsync(() => Folders.AddRange(folders.Where(f => Folders.All(folder => folder.Name != f.Name))));
        }

        private Task<List<IBrowserObject>> GetFoldersAsync(DirectoryInfo info,  Func<IFolderFactory> folderFactoryMethod)
        {
            return Task.Factory.StartNew(() => GetFolders(info, folderFactoryMethod));
        }

        private List<IBrowserObject> GetFolders(DirectoryInfo info,  Func<IFolderFactory> folderFactoryMethod)
        {
                var folders = new List<IBrowserObject>();

                foreach (var dirInfo in info.GetDirectories())
                {
                    try
                    {
                        var folder = folderFactoryMethod().Create(dirInfo, false);
                        if (!string.IsNullOrWhiteSpace(folder.Name))
                            folders.Add(folder);
                    }
                    catch
                    {
                        continue;
                    }
                }
                return folders;
        }

        public string Name { get; set; }
        public string Path { get; set; }

        public ImageSource Image { get; set; }

        public ObservableCollection<IBrowserObject> Folders { get; set; } = new ObservableCollection<IBrowserObject>();
        public ObservableCollection<IBrowserObject> Files { get; set; } = new ObservableCollection<IBrowserObject>();
        public IBrowserObject Create(DirectoryInfo info, bool asynchronously = true)
            => new Folder(_folderFactoryMethod, info, asynchronously);
    }
}
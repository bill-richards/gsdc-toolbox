using System.Windows.Media;
using Prism.Mvvm;

namespace gsdc.toolbox.dialogs.ViewModels
{
    public class BrowserFile : BindableBase, IBrowserObject
    {
        public ImageSource Image { get; set; }
        public string Name { get; set; }

        public string Path { get; set; }
    }
}
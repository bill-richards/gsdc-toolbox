using System;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Windows.Interop;
using gsdc.toolbox.dialogs.ViewModels;

namespace gsdc.toolbox.dialogs.Views
{
    public partial class FolderBrowser : IClosable
    {
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public FolderBrowser() 
            => InitializeComponent();

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var handle = new WindowInteropHelper(this).Handle;
            SetWindowLong(handle, GWL_STYLE, GetWindowLong(handle, GWL_STYLE) & ~WS_SYSMENU);
        }

        private void HeaderMouseDown(object sender, MouseButtonEventArgs e) 
            => DragMove();
    }
}

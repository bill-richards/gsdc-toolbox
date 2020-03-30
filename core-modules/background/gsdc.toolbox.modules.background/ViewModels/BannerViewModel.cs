using System.Windows.Media;
using Prism.Mvvm;

namespace gsdc.toolbox.modules.background.ViewModels
{
    internal class BannerViewModel : BindableBase
    {
        public string CompanyName
            => "gsdc";

        public string ApplicationName 
            => "Toolbox";

        public Brush CompanyNameColour
            // ReSharper disable once PossibleNullReferenceException
            => new SolidColorBrush{Color = (Color)ColorConverter.ConvertFromString("#FFC5BC25") };

        public Brush ApplicationNameColour
            // ReSharper disable once PossibleNullReferenceException
            => new SolidColorBrush{Color = (Color)ColorConverter.ConvertFromString("#FFC4CFD6") };
        
    }
}
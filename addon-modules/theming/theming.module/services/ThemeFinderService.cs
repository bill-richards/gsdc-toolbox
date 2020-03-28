using gsdc.toolbox;
using gsdc.toolbox.addons;

namespace themes.services
{
    internal class ThemeFinderService : IThemeFinderService
    {
        private readonly IAddOnService _addOnService;
        private readonly IApplicationService _applicationService;

        public ThemeFinderService(IAddOnService addOnService, IApplicationService applicationService)
        {
            _addOnService = addOnService;
            _applicationService = applicationService;
        }

        public void FindThemes() 
            => _addOnService.LoadAddOns(_applicationService.GetSubDirectory(_applicationService.AddOnsDirectoryName, "theming", "themes"));
    }
}
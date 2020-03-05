using gsdc.toolbox;
using gsdc.toolbox.addons;

namespace themes.services
{
    internal class ThemeFinderService : IThemeFinderService
    {
        private readonly IAddOnService _addOnService;

        public ThemeFinderService(IAddOnService addOnService) 
            => _addOnService = addOnService;

        public void FindThemes() 
            => _addOnService.LoadAddOns(ApplicationPath.GetSubDirectory("add-ons", "theming", "themes"));
    }
}
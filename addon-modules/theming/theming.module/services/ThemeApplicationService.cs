using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using gsdc.toolbox.events;
using Prism.Events;

namespace toolbox.themes.services
{
    internal class ThemeApplicationService : IThemeApplicationService
    {
        private readonly IThemeCacheService _themeCacheService;
        private readonly IThemeFactory _themeFactory;
        private readonly Action<ResourceDictionary> _publishAddResourceDictionaryEvent;

        private List<ITheme> ThemeList { get; } = new List<ITheme>();

        public ThemeApplicationService(IEventAggregator eventAggregator, IThemeCacheService themeCacheService, IThemeFactory themeFactory)
        {
            _publishAddResourceDictionaryEvent = eventAggregator.GetEvent<AddResourceDictionary>().Publish;
            _themeCacheService = themeCacheService;
            _themeFactory = themeFactory;
        }

        public void CreateThemeList(Assembly executingAssembly)
        {
            _themeCacheService.CacheResourceDictionariesFromThisAssembly(executingAssembly);
            foreach (var entry in _themeCacheService.ReadCachedThemes())
                ThemeList.Add(_themeFactory.CreateTheme(entry.Key, entry.Value));
        }

        public void ApplyTheme(string themeName) 
            => _publishAddResourceDictionaryEvent?.Invoke(ThemeList.First(theme => theme.Name == themeName).ResourceDictionary);
    }
}
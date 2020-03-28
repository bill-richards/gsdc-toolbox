using System.Collections.Generic;
using System.Reflection;
using System.Windows;

namespace themes
{
    public interface IThemeCacheService
    {
        void CacheResourceDictionariesFromTheseAssemblies(IEnumerable<string> assemblyNames);
        void CacheResourceDictionariesFromThisAssembly(Assembly assembly);
        IEnumerable<string> GetThemeNames();
        IEnumerable<KeyValuePair<string, ResourceDictionary>> ReadCachedThemes();
    }
}
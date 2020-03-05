using System.Collections.Generic;
using System.Reflection;
using System.Windows;

namespace themes
{
    public interface IThemeCacheService
    {
        void CacheResourceDictionariesFromTheseAssemblies(IEnumerable<string> assemblyNames);
        IEnumerable<KeyValuePair<string, ResourceDictionary>> ReadCachedThemes();
        void CacheResourceDictionariesFromThisAssembly(Assembly assembly);
    }
}
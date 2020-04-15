using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows;
using System.Windows.Baml2006;
using System.Windows.Markup;
using gsdc.toolbox;

namespace toolbox.themes.services
{
    internal class ThemeCacheService : IThemeCacheService
    {
        private IDictionary<string, ResourceDictionary> Dictionaries { get; set; }

        public void CacheResourceDictionariesFromTheseAssemblies(IEnumerable<string> assemblyNames)
        {
            Dictionaries = new Dictionary<string, ResourceDictionary>();

            foreach (var file in assemblyNames)
                CacheTheResourceDictionariesFromThisAssembly(file);
        }

        public void CacheResourceDictionariesFromThisAssembly(Assembly assembly)
        {
            Dictionaries = new Dictionary<string, ResourceDictionary>();
            CacheTheResourceDictionariesFromThisAssembly(assembly);
        }

        public IEnumerable<string> GetThemeNames()
           => Dictionaries.Keys.OrderBy(key => key);

        public IEnumerable<KeyValuePair<string, ResourceDictionary>> ReadCachedThemes()
           => Dictionaries.OrderBy(e => e.Key);
        private void CacheTheResourceDictionariesFromThisAssembly(Assembly asm)
        {
            var stream = asm.GetManifestResourceStream(asm.GetName().Name + ".g.resources");
            if (stream == null) return;

            try
            {
                using var reader = new ResourceReader(stream);
                foreach (DictionaryEntry entry in reader)
                {
                    if (!(entry.Value is Stream readStream)) continue;

                    var bamlReader = new Baml2006Reader(readStream);
                    var loadedObject = XamlReader.Load(bamlReader);
                    if (!(loadedObject is ResourceDictionary)) continue;

                    var key = entry.Key.ToString();
                    // ReSharper disable once PossibleNullReferenceException
                    var themeName = key.Substring(key.LastIndexOf('/') + 1).Replace(".baml", string.Empty).UppercaseWords();
                    Dictionaries.Add(themeName, loadedObject as ResourceDictionary);
                }
            }
            catch (Exception) { /**/ }
        }

        private void CacheTheResourceDictionariesFromThisAssembly(string assemblyName)
        {
            var asm = Assembly.LoadFrom(assemblyName);

            var stream = asm.GetManifestResourceStream(asm.GetName().Name + ".g.resources");
            if (stream == null) return;

            try
            {
                using var reader = new ResourceReader(stream);
                foreach (DictionaryEntry entry in reader)
                {
                    if (!(entry.Value is Stream readStream)) continue;

                    var bamlReader = new Baml2006Reader(readStream);
                    var loadedObject = XamlReader.Load(bamlReader);
                    if (!(loadedObject is ResourceDictionary)) continue;

                    var key = entry.Key.ToString();
                    // ReSharper disable once PossibleNullReferenceException
                    var themeName = key.Substring(key.LastIndexOf('/') + 1).Replace(".baml", string.Empty).UppercaseWords();
                    Dictionaries.Add(themeName, loadedObject as ResourceDictionary);
                }
            }
            catch (Exception) { /**/ }
        }

    }
}
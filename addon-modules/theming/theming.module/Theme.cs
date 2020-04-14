using System.Windows;

namespace toolbox.themes
{
    internal class Theme : ITheme, IThemeFactory
    {
        public Theme() { }

        private Theme(string name, ResourceDictionary resourceDictionary)
        {
            Name = name;
            ResourceDictionary = resourceDictionary;
        }

        public string Name { get; }
        public ResourceDictionary ResourceDictionary { get; }

        public ITheme CreateTheme(string name, ResourceDictionary resourceDictionary)
            => new Theme(name, resourceDictionary);
    }
}
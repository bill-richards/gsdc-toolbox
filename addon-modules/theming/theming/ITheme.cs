using System.Windows;

namespace toolbox.themes
{
    public interface ITheme
    {
        string Name { get; }
        ResourceDictionary ResourceDictionary { get; }
    }

    public interface IThemeFactory
    {
        ITheme CreateTheme(string name, ResourceDictionary resourceDictionary);
    }
}
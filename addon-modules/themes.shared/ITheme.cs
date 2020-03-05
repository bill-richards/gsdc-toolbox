using System.Reflection.Metadata.Ecma335;
using System.Windows;

namespace themes
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
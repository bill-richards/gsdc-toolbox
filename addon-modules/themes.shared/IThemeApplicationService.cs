using System.Reflection;
using System.Windows;

namespace themes
{
    public interface IThemeApplicationService
    {
        void CreateThemeList(Assembly executingAssembly);
        void ApplyTheme(string themeName);
    }
}
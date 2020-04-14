using System.Reflection;

namespace toolbox.themes
{
    public interface IThemeApplicationService
    {
        void CreateThemeList(Assembly executingAssembly);
        void ApplyTheme(string themeName);
    }
}
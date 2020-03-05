using System.Reflection;

namespace themes
{
    public interface IThemeApplicationService
    {
        void CreateThemeList(Assembly executingAssembly);
        void ApplyTheme(string themeName);
    }
}
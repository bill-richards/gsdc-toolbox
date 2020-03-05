using System.Collections.Generic;
using System.IO;

namespace gsdc.toolbox
{
    public static class ApplicationPath
    {
        public static string Get()
            => Directory.GetCurrentDirectory();

        public static string GetSubDirectory(params string[] directories)
        {
            var allDirectories = new List<string>{ Directory.GetCurrentDirectory() };
            allDirectories.AddRange(directories);
            return Path.Join(allDirectories.ToArray());
        }
    }
}
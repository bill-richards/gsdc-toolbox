using System.Collections.Generic;
using System.IO;

namespace gsdc.toolbox
{
    public class ApplicationService : IApplicationService
    {
        public string AddOnsDirectory => GetSubDirectory(AddOnsDirectoryName);
        public string AddOnsDirectoryName => "add-on-modules";
        public string CoreModulesDirectory => GetSubDirectory("core-modules");

        public string GetRootPath()
            => Directory.GetCurrentDirectory();

        public string GetSubDirectory(params string[] directories)
        {
            var allDirectories = new List<string>{ GetRootPath() };
            allDirectories.AddRange(directories);
            return Path.Join(allDirectories.ToArray());
        }
    }
}

using System.Collections.Generic;

namespace gsdc.toolbox
{
   public static class RegionNames
   {
      public static readonly string ShellBackgroundRegion = "{4655BBAE-342D-4B12-AA80-DE2648E3FAB1}";
      //public static readonly string ShellBannerRegion = "{2142FAF0-158B-400A-BF5E-72035E5636CB}";
      public static readonly string ShellApplicationsRegion = "{CC0C2909-0B51-4E35-9B64-80F01DBC9699}";
      public static readonly string ShellMenu = "{851EED84-FFE4-4003-B070-55AFEE7BE0A7}";
      public static readonly string ShellToolboxMenu = "{E0CE475B-D185-4ED7-B565-BD0E70CBD3A5}";
      public static readonly string ShellMainRegion = "{5CA8814F-9EA0-4FAC-A607-E75E30154A49}";
      public static readonly string ShellBottomLeftRegion = "{A8A14CFB-6EE9-4DEC-8B85-DF84588F6443}";
      public static readonly string ShellRightRegion = "{8E3E23AD-8737-4386-97B2-DE88664310DA}";
      public static readonly string ShellTopLeftRegion = "{C1864A6A-681B-4A21-9FEE-97F3A44E2E7C}";
      public static readonly string ShellToolbarRegion = "{7B2A49BF-34E0-43D7-A2EF-B5963E5765E7}";
      public static readonly string ShellOverlayRegion = "{658330B3-4F45-4358-BE58-F963A7525532}";
      public static readonly string ShellToolboxMenuHolder = "{02975883-207E-4DCE-B565-7E2BA82E88CC}";
      public static readonly string ShellLeftSidebarHolder = "{F6FE7087-055E-4394-A29A-69BA5930087A}";
      public static readonly string ShellRightSidebarHolder = "{CDC96A8B-EF4F-4C3A-8305-E0FC8B7F6CD3}";

      private static readonly Dictionary<string, string> RegionNamesDictionary = new Dictionary<string, string>
      {
         {"ShellBackgroundRegion", ShellBackgroundRegion },
         //{"ShellBannerRegion", ShellBannerRegion },
         {"ShellApplicationsRegion", ShellApplicationsRegion },
         {"ShellMenu", ShellMenu },
         {"ShellMainRegion", ShellMainRegion },
         {"ShellTopLeftRegion", ShellTopLeftRegion },
         {"ShellRightRegion", ShellRightRegion },
         {"ShellBottomLeftRegion", ShellBottomLeftRegion },
         {"ShellToolboxMenu", ShellToolboxMenu },
         {"ShellToolbarRegion", ShellToolbarRegion },
         {"ShellLeftSidebarHolder", ShellLeftSidebarHolder },
         {"ShellRightSidebarHolder", ShellRightSidebarHolder },
         {"ShellToolboxMenuHolder", ShellToolboxMenuHolder },
         {"ShellOverlayRegion", ShellOverlayRegion }
      };

      public static string GetShellRegionName(string regionId)
      {
         return RegionNamesDictionary[regionId];
      }
   }
}

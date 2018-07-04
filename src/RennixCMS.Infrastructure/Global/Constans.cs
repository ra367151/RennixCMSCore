using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Global
{
    public class Constans
    {
        public class SettingKeys
        {
            public class Site
            {
                public const string SiteName = "system.site.siteName";
            }
            public class Theme
            {
                public const string CurrentTheme = "system.theme.currentTheme";
            }
            public class StaticPage
            {
                public const string EnableStaticPages = "system.staticPage.enableStaticPages";
            }

            public class Menu
            {
                public const string FrontEndMenus = "system.menu.frontendMenus";
            }
        }

        public class Theme
        {
            public const string DefaultTheme = "Default";
        }
    }
}

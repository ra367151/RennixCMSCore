using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace RennixCMS.Infrastructure.Mvc
{
    public class ThemViewLocationExpander : IViewLocationExpander
    {
        public static string CurrentTheme = null;
        public static bool? EnableStaticPages = null;

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            IEnumerable<string> viewLocationResult = new List<string>();
            // 如果需要做页面静态化的视图查找 可以在这里进行扩展
            if (context.Values.ContainsKey("theme"))
            {
                // todo:先判断静态页面是否存在 如果不存在 则返回动态结果
                if (EnableStaticPages != null && EnableStaticPages.Value)
                {
                    viewLocationResult = viewLocations.Select(f => f.Replace("/Views/", "/Statics/").Replace(".cshtml",".html"));
                }
                else
                {
                    viewLocationResult = viewLocations.Select(f => f.Replace("/Views/", "/Themes/" + context.Values["theme"] + "/"));
                }
            }
            else
            {
                viewLocationResult = viewLocations;
            }
            return viewLocationResult;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            if (IgnoreThemeAreaNames.Contains(context.AreaName?.ToLower()))
                return;

            if (IgnoreThemeControllerActionNames.Contains($"{context.ControllerName}/{context.ViewName}".ToLower()))
                return;

            context.Values["theme"] = CurrentTheme;
        }

        private IList<string> IgnoreThemeAreaNames => new List<string>
        {
            "admin"
        };

        private IList<string> IgnoreThemeControllerActionNames => new List<string>
        {
            "account/login",
            "account/register"
        };
    }
}

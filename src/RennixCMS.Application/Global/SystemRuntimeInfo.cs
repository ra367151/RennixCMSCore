using RennixCMS.Domain.Menu.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Application.Global
{
    public class SystemRuntimeInfo
    {
        public string SiteName { get; set; }
        public IEnumerable<MenuDto> Menus { get; set; }
        public string Theme { get; set; }

        public static SystemRuntimeInfo Instance
            => new SystemRuntimeInfo
            {
                Menus = new List<MenuDto>
                {
                    new MenuDto { Name = "所有文章", Path = "/", Icon = null ,Sort=0},
                    new MenuDto { Name = "分类", Path = "/Category/Index", Icon = null ,Sort=1},
                    new MenuDto { Name = "开源", Path = "http://rennix09@github.com", Icon = null ,Sort=2},
                    new MenuDto { Name = "关于我", Path = "#", Icon = null ,Sort=3}
                },
                SiteName = "Rennix's Blog",
                Theme = "Default"
            };
    }
}

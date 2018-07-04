using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RennixCMS.Application.Global;
using RennixCMS.Application.Setting;
using RennixCMS.Domain.Menu.Dtos;
using RennixCMS.Infrastructure.Global;
using RennixCMS.Infrastructure.WebApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RennixCMS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [WrapWebApiException]
    public class SystemController:Controller
    {
        private readonly ISettingAppService _settingService;
        public SystemController(ISettingAppService settingService)
        {
            _settingService = settingService;
        }

        [HttpGet]
        public async Task<ResponseResult<SystemRuntimeInfo>> GetSystemRuntimeInfo()
        {
            var result = new SystemRuntimeInfo
            {
                Menus = JsonConvert.DeserializeObject<IEnumerable<MenuDto>>(_settingService.GetSetting(Constans.SettingKeys.Menu.FrontEndMenus).Value),
                Theme = "Default",
                SiteName = "Rennix's Blog"
            };

            return ResponseResult. Create(result);
        }
    }
}

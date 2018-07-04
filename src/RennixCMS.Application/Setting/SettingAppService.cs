using Newtonsoft.Json;
using RennixCMS.Domain.Menu.Dtos;
using RennixCMS.Domain.Setting.Dtos;
using RennixCMS.Infrastructure.ApplicationService;
using RennixCMS.Infrastructure.Global;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RennixCMS.Application.Setting
{
    public class SettingAppService : ApplicationService, ISettingAppService
    {
        
        public SettingAppService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
        public SettingDto GetSetting(string key)
        {
            if (key == Constans.SettingKeys.Theme.CurrentTheme)
            {
                return new SettingDto
                {
                    Value = "Default"
                };
            }
            if (key == Constans.SettingKeys.Menu.FrontEndMenus)
            {
                return new SettingDto
                {
                    Value = JsonConvert.SerializeObject(new List<MenuDto>
                    {
                         new MenuDto{ Name = "所有文章",Path ="/",Icon=null},
                         new MenuDto{ Name = "分类",Path ="/Category/Index",Icon=null},
                         new MenuDto{ Name = "开源",Path ="http://rennix09@github.com",Icon=null},
                         new MenuDto{ Name = "关于我",Path ="#",Icon=null}
                    })
                };
            }
            if (key == Constans.SettingKeys.Site.SiteName)
            {
                return new SettingDto
                {
                    Value = "Rennix's Blog"
                };
            }
            return null;
        }

        public SettingDto GetSetting(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SettingDto> GetSettings(string keyPrefix)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSetting(IEnumerable<UpdateSettingDto> settings)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSetting(UpdateSettingDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

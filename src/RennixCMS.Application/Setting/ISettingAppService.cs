using RennixCMS.Domain.Setting.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RennixCMS.Application.Setting
{
    public interface ISettingAppService
    {
        Task UpdateSetting(IEnumerable<UpdateSettingDto> settings);
        Task UpdateSetting(UpdateSettingDto dto);
        SettingDto GetSetting(string key);
        SettingDto GetSetting(int id);
        IEnumerable<SettingDto> GetSettings(string keyPrefix);
    }
}

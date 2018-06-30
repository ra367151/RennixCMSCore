using RennixCMS.Domain.Setting.Dtos;
using RennixCMS.Infrastructure.ApplicationService;
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
            return new SettingDto
            {
                Value = "Default"
            };
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

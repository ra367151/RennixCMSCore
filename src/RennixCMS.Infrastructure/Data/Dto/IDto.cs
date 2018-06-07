using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Data.Dto
{
    public interface IDto
    {
        /// <summary>
        /// 验证字段
        /// </summary>
        /// <returns></returns>
        void ValidateProperties();
    }
}

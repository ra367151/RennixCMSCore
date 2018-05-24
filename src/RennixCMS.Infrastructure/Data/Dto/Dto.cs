using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RennixCMS.Infrastructure.Data.Dto
{
    public abstract class Dto : IDto
    {
        /// <summary>
        /// 验证字段
        /// </summary>
        /// <returns></returns>
        public abstract bool ValidateProperties();
    }
}

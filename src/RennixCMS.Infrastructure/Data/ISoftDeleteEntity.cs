using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Data
{
    public interface ISoftDeleteEntity:IEntity
    {
		/// <summary>
		/// 是否被删除
		/// </summary>
		bool IsDelete { get; set; }
		
    }
}

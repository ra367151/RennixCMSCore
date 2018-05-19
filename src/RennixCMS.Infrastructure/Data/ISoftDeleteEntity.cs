using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Data
{
    public interface ISoftDeleteEntity<TKey> : IEntity<TKey>
	{
		/// <summary>
		/// 是否被删除
		/// </summary>
		bool IsDelete { get; set; }
		
    }
}

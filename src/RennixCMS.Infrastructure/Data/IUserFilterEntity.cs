using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Data
{
    public interface IUserFilterEntity<TKey>:IEntity<TKey>
    {
		/// <summary>
		/// 此记录所属的用户id
		/// </summary>
		 Guid UserId { get; set; }
    }
}

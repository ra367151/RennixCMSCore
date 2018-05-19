using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Data
{
    public interface IUserFilterEntity:IEntity
    {
		/// <summary>
		/// 此记录所属的用户id
		/// </summary>
		 int UserId { get; set; }
    }
}
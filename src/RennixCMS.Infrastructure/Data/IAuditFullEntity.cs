﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Data
{
	public interface IAuditFullEntity : IEntity
	{
		/// <summary>
		/// 创建时间
		/// </summary>
		DateTime CreateTime { get; set; }

		/// <summary>
		/// 创建的用户id
		/// </summary>
		int CreateUserId { get; set; }

		/// <summary>
		/// 最后修改的时间
		/// </summary>
		DateTime? LastModifyTime { get; set; }

		/// <summary>
		/// 最后修改的用户id
		/// </summary>
		int LastModifyUserId { get; set; }

	}
}

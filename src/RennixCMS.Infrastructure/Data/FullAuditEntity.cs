﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Data
{
	public class FullAuditEntity<TKey> : IAuditFullEntity<TKey>
	{
		public DateTime CreateTime { get; set; }
		public Guid CreateUserId { get; set; }
		public DateTime? LastModifyTime { get; set; }
		public Guid LastModifyUserId { get; set; }
		public bool IsDelete { get; set; }
		public TKey Id { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Data
{
	public class FullAuditEntity : IAuditFullEntity
	{
		public DateTime CreateTime { get; set; }
		public int CreateUserId { get; set; }
		public DateTime? LastModifyTime { get; set; }
		public int LastModifyUserId { get; set; }
		public bool IsDelete { get; set; }
		public int Id { get; set; }
	}
}

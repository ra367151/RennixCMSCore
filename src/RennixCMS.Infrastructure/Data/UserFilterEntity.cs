using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Data
{
	public class UserFilterEntity<TKey> : IUserFilterEntity<TKey>
	{
		public Guid UserId { get; set; }
		public TKey Id { get; set; }
	}
}

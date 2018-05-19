using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Data
{
	public class Entity<TKey> : IEntity<TKey>
	{
		public TKey Id { get; set; }
	}
}

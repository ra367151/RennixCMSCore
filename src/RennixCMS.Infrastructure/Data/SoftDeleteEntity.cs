using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Data
{
	public class SoftDeleteEntity<TKey> : ISoftDeleteEntity<TKey>
	{
		public bool IsDelete { get; set; }
		public TKey Id { get; set; }
	}
}

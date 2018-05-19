using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Data
{
	public class SoftDeleteEntity : ISoftDeleteEntity
	{
		public bool IsDelete { get; set; }
	}
}

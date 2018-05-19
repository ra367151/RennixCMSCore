using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Data
{
	public interface IEntity<TKey>
	{
		TKey Id { get; set; }
	}
}

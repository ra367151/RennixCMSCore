using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RennixCMS.Infrastructure.Data;

namespace RennixCMS.Infrastructure.Extionsions
{
    public static class IEntityExtension
    {
		public static bool IsTransient(this IEntity source)
		{
			var props = source.GetType().GetProperties();
			return props.Any(x => x.Name.Equals("Id", StringComparison.CurrentCultureIgnoreCase));
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Extionsions
{
    public static class ICollectionExtension
	{
		public static bool IsNullOrEmpty(this ICollection source)
		{
			if (source == null || source.Count <= 0)
			{
				return true;
			}
			return false;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Extionsions
{
	public static class StringExtension
	{
		public static bool IsNullOrEmpty(this string source)
		{
			return string.IsNullOrEmpty(source);
		}
	}
}

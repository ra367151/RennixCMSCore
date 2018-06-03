using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RennixCMS.Infrastructure.Extionsions
{
    public static class IQueryableExtensions
    {
		public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, bool excuteFilter, Expression<Func<T, bool>> expression)
		{
			if (excuteFilter)
			{
				return source.Where(expression);
			}
			return source;
		}
    }
}

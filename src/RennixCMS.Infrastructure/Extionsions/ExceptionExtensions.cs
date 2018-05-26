using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RennixCMS.Infrastructure.Extionsions
{
	public static class ExceptionExtensions
	{
		/// <summary>
		/// 获取友好的错误信息
		/// </summary>
		/// <param name="exception"></param>
		/// <returns></returns>
		public static string GetFriendlyMessage(this Exception exception)
		{
			if (exception == null)
			{
				return string.Empty;
			}

			var friendlyMsg = exception.Message;

			var aggregateException = exception as AggregateException;
			if (aggregateException != null)
			{
				aggregateException = aggregateException.Flatten();
				if (aggregateException.InnerExceptions.Any())
				{
					friendlyMsg = aggregateException.InnerExceptions
									  .Aggregate(friendlyMsg,
									  (msgAccumulator, exNext) =>
									  {
										  msgAccumulator += $"{System.Environment.NewLine}{exNext.Message}";
										  return msgAccumulator;
									  });
				}
			}

			return friendlyMsg;
		}
	}
}

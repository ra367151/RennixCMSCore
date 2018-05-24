using System;
using System.Collections.Generic;
using System.Text;
using RennixCMS.Infrastructure.Data.Dto;

namespace RennixCMS.Infrastructure.Data
{
	public class PageResult<TData> where TData : class, IDto
	{
		public int PageIndex { get; set; }

		public int PageSize { get; set; }

		public int TotalCount { get; set; }

		public IList<TData> Data { get; set; }
	}
}

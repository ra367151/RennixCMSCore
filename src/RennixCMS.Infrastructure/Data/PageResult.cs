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

		public int TotalPages => Convert.ToInt32(Math.Ceiling(TotalCount * 1.0 / PageSize * 1.0));

		public bool HasPreviewPage => PageIndex > 1 && PageIndex <= TotalPages;

		public bool HasNextPage => PageIndex < TotalPages;
	}
}

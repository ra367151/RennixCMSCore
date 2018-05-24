using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Data
{
	public class PageQueryDto
	{
		public PageQueryDto()
		{
			this.PageSize = 20;
			this.PageIndex = 1;
		}

		public int PageIndex { get; set; }

		public int PageSize { get; set; }

    }
}

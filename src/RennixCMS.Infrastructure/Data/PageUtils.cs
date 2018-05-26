using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Data
{
	public class PageUtils
	{
		public static SkipTake GetSkipTake(PageQueryDto dto)
		{
			return new SkipTake
			{
				Skip = (dto.PageIndex - 1) * dto.PageSize,
				Take = dto.PageSize
			};
		}
	}

	public class SkipTake
	{
		public int Skip { get; set; }

		public int Take { get; set; }
	}
}

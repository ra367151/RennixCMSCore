﻿using System;
using System.Collections.Generic;
using System.Text;
using RennixCMS.Infrastructure.Data;
using RennixCMS.Infrastructure.Data.Dto;

namespace RennixCMS.Domain.Post.Dtos
{
	public class PostFilterDto : PageQueryDto, IDto
	{
		public string CategoryName { get; set; }
		
		public int? CategoryId { get; set; }

		public string Title { get; set; }

		public string Content { get; set; }

		public string Author { get; set; }

		public DateTime? BeginCreateTime { get; set; }

		public DateTime? EndCreateTime { get; set; }
		public bool IsVisiable { get; set; }

		public bool ValidateProperties()
		{
			return true;
		}
	}
}
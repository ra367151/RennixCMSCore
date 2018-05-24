using System;
using System.Collections.Generic;
using System.Text;
using RennixCMS.Infrastructure.Data.Dto;

namespace RennixCMS.Domain.Post.Dtos
{
	public class CreatePostDto : IDto
	{
		public int CategoryId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public string Author { get; set; }
		public string Link { get; set; }
		public bool IsVisiable { get; set; }
		public bool ValidateProperties()
		{
			return true;
		}
	}
}

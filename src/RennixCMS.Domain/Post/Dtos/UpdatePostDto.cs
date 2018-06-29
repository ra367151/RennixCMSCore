using System;
using System.Collections.Generic;
using System.Text;
using RennixCMS.Infrastructure.Data.Dto;

namespace RennixCMS.Domain.Post.Dtos
{
	public class UpdatePostDto : IDto
	{
		public int Id { get; set; }
		public int CategoryId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
        public string ContentHTML { get; set; }
        public string Author { get; set; }
		public string Link { get; set; }
		public bool IsVisiable { get; set; }

		public void ValidateProperties()
		{
			
		}
	}
}

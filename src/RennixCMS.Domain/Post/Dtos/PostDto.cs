using System;
using System.Collections.Generic;
using System.Text;
using RennixCMS.Infrastructure.Data.Dto;

namespace RennixCMS.Domain.Post.Dtos
{
	/// <summary>
	/// PostDto
	/// </summary>
    public class PostDto:IDto
    {
		public int Id { get; set; }
		public int CategoryId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
        public string ContentHTML { get; set; }
        public string Author { get; set; }
		public string Link { get; set; }
		public DateTime CreateTime { get; set; }
		public int CreateUserId { get; set; }
		public DateTime? LastModifyTime { get; set; }
		public int LastModifyUserId { get; set; }
		public bool IsDelete { get; set; }
		public bool IsVisiable { get; set; }

		public virtual Domain.Category.Dtos.CategoryDto Category { get; set; }
		public virtual IEnumerable<Domain.Comment.Dtos.CommentDto> Comments { get; set; }

		public void ValidateProperties()
		{
			
		}
	}
}

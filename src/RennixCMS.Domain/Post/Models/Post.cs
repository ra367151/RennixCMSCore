using System;
using System.Collections.Generic;
using System.Text;
using RennixCMS.Infrastructure.Data;

namespace RennixCMS.Domain.Post.Models
{
	public class Post : IAuditFullEntity
	{
		public int Id { get; set; }
		public int CategoryId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public string Author { get; set; }
		public string Link { get; set; }
		public DateTime CreateTime { get; set; }
		public int CreateUserId { get; set; }
		public DateTime? LastModifyTime { get; set; }
		public int LastModifyUserId { get; set; }
		public bool IsVisiable { get; set; }

		public virtual Domain.Category.Models.Category Category { get; set; }
		public virtual IEnumerable<Comment.Models.Comment> Comments { get; set; }
	}
}

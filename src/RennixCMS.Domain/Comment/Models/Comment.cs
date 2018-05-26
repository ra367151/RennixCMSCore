using System;
using System.Collections.Generic;
using System.Text;
using RennixCMS.Infrastructure.Data;

namespace RennixCMS.Domain.Comment.Models
{
    public class Comment : IAuditFullEntity
    {
		public int Id { get; set; }
		public int ParentId { get; set; }
		public int UserId { get; set; }
		public string Content { get; set; }
		public string PostId { get; set; }
		public string Author { get; set; }
		public string AuthorIp { get; set; }
		public bool IsVisible { get; set; }
		public DateTime CreateTime { get; set; }
		public int CreateUserId { get; set; }
		public DateTime? LastModifyTime { get; set; }
		public int LastModifyUserId { get; set; }

		public virtual Post.Models.Post Post { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using RennixCMS.Infrastructure.Data.Dto;

namespace RennixCMS.Domain.Post.Dtos
{
    /// <summary>
    /// PostDto
    /// </summary>
    public class PostDto : IDto
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

        public string Description => ReplaceHtmlTag(200);

        public int Length => ReplaceHtmlTag().Length;
        public int ReadMiniutes => this.Length <= 450 ?1 : this.Length <= 450*2 ? 2: this.Length / 450;

        public virtual Domain.Category.Dtos.CategoryDto Category { get; set; }
		public virtual IEnumerable<Domain.Comment.Dtos.CommentDto> Comments { get; set; }

		public void ValidateProperties()
		{
			
		}

        public string ReplaceHtmlTag(int length=int.MaxValue)
        {
            string strText = System.Text.RegularExpressions.Regex.Replace(this.ContentHTML??string.Empty, "<[^>]+>", "");

            strText = System.Text.RegularExpressions.Regex.Replace(strText, "&[^;]+;", "");

            if (length > 0 && strText.Length > length)
                return strText.Substring(0, length);

            return strText;
        }
    }
}

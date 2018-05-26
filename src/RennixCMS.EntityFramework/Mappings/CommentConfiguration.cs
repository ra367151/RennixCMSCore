using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RennixCMS.Domain.Comment.Models;
using RennixCMS.EntityFramework.Configuration;

namespace RennixCMS.EntityFramework.Mappings
{
	public class CommentConfiguration : ModelConfiguration<Comment>
	{
		public override void Configure(EntityTypeBuilder<Comment> builder)
		{
			builder.ToTable("Comment");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Author).HasMaxLength(20).IsRequired();
			builder.Property(x => x.AuthorIp).HasMaxLength(20);
			builder.Property(x => x.Content).IsRequired();
			builder.Property(x => x.CreateTime).IsRequired();
			builder.Property(x => x.CreateUserId).IsRequired();
			builder.Property(x => x.IsVisible).IsRequired().HasDefaultValue(true);
			builder.Property(x => x.LastModifyTime);
			builder.Property(x => x.LastModifyUserId);
			builder.Property(x => x.ParentId).IsRequired().HasDefaultValue(0);
			builder.Property(x => x.PostId).IsRequired();
			builder.Property(x => x.UserId).IsRequired();

			builder.HasOne(x => x.Post)
				.WithMany(x => x.Comments);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RennixCMS.Domain.Post.Models;
using RennixCMS.EntityFramework.Configuration;

namespace RennixCMS.EntityFramework.Mappings
{
	public class PostConfiguration : ModelConfiguration<Post>
	{
		public override void Configure(EntityTypeBuilder<Post> builder)
		{
			builder.ToTable("Post");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Author).HasMaxLength(20).IsRequired();
			builder.Property(x => x.CategoryId).IsRequired();
			builder.Property(x => x.Content).IsRequired();
			builder.Property(x => x.CreateTime).IsRequired();
			builder.Property(x => x.CreateUserId).IsRequired();
			builder.Property(x => x.IsVisiable).IsRequired().HasDefaultValue(true);
			builder.Property(x => x.LastModifyTime);
			builder.Property(x => x.LastModifyUserId);
			builder.Property(x => x.Link).HasMaxLength(300);
			builder.Property(x => x.Title).HasMaxLength(50).IsRequired();

			builder.HasMany(x => x.Comments)
				.WithOne(x => x.Post)
				.HasForeignKey(x => x.PostId);
		}
	}
}

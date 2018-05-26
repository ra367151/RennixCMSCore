using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RennixCMS.Domain.Category.Models;
using RennixCMS.EntityFramework.Configuration;

namespace RennixCMS.EntityFramework.Mappings
{
	public class CategoryConfiguration : ModelConfiguration<Category>
	{
		public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("Category");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Description).HasMaxLength(100);
			builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
			builder.Property(x => x.ParentId).IsRequired().HasDefaultValue(0);

			builder.HasMany(x => x.Posts)
				.WithOne(x => x.Category)
				.HasForeignKey(x => x.CategoryId);
		}
	}
}

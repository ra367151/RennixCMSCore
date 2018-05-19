using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RennixCMS.Infrastructure.Data;

namespace RennixCMS.EntityFramework.Configuration
{
	public abstract class ModelConfiguration<T> : IEntityTypeConfiguration<T> where T : class,IEntity
	{
		public abstract void Configure(EntityTypeBuilder<T> builder);
	}
}
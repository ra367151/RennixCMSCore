using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RennixCMS.Infrastructure.Data;

namespace RennixCMS.EntityFramework.Configuration
{
	public abstract class ModelConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class, IEntity
	{
		public abstract void Configure(EntityTypeBuilder<TEntity> builder);
	}
}
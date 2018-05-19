using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RennixCMS.Infrastructure.Data;

namespace RennixCMS.EntityFramework.Configuration
{
	public abstract class ModelConfiguration<TEntity,TKey> : IEntityTypeConfiguration<TEntity> where TEntity : class,IEntity<TKey>
	{
		public abstract void Configure(EntityTypeBuilder<TEntity> builder);
	}
}
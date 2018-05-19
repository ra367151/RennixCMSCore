using System;
using System.Collections.Generic;
using System.Text;
using RennixCMS.EntityFramework.DbContext;
using RennixCMS.Infrastructure.Data;

namespace RennixCMS.EntityFramework.Repositories
{
    public class EfRepository<TEntity> : EfRepositoryBase<TEntity>
		where TEntity : class,IEntity
	{
		public EfRepository(ApplicationDbContext dbContext):base(dbContext)
		{
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using RennixCMS.EntityFramework.DbContext;
using RennixCMS.EntityFramework.UnitOfWork;
using RennixCMS.Infrastructure.Data;

namespace RennixCMS.EntityFramework.Repositories
{
    public class EfRepository<TEntity> : EfRepositoryBase<TEntity>
		where TEntity : class,IEntity
	{
		public EfRepository(IUnitOfWorkContext dbContext):base(dbContext)
		{
		}
	}
}

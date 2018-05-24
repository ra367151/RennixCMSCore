using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RennixCMS.Infrastructure.Data.Repository;

namespace RennixCMS.Infrastructure.Data.UnitOfWork
{
	public interface IUnitOfWork:IDisposable
	{
		IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity;

		Task<int> SaveChangesAsync();
	}
}

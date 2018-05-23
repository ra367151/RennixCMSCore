using System;
using System.Collections.Generic;
using System.Text;
using RennixCMS.Infrastructure.Data.Repository;

namespace RennixCMS.Infrastructure.Data.UnitOfWork
{
	public interface IUnitOfWork
	{
		IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity;

		void Commit();
	}
}

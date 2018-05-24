using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RennixCMS.EntityFramework.DbContext;
using RennixCMS.Infrastructure.Data;
using RennixCMS.Infrastructure.Data.Repository;
using RennixCMS.Infrastructure.Data.UnitOfWork;

namespace RennixCMS.EntityFramework.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{

		private bool _disposed;
		private readonly ApplicationDbContextBase _dbContext;
		private readonly IServiceProvider _serviceProvider;
		private Hashtable _repositories;
        private bool _hasCommited = false;

		public UnitOfWork(ApplicationDbContextBase dbContext, IServiceProvider serviceProvider)
		{
			this._dbContext = dbContext;
			this._serviceProvider = serviceProvider;
			this._repositories = new Hashtable();
		}

		public virtual void Dispose(bool disposing)
		{
			if (!this._disposed)
			{
				if (disposing)
				{
					this._dbContext.Dispose();
				}
			}
			this._disposed = true;
		}

		#region IUnitOfWork 成员

		public IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity
		{
			var typeName = typeof(TEntity).Name;

			if (!this._repositories.ContainsKey(typeName))
			{
				var paramDict = new Dictionary<string, object>();
				paramDict.Add("context", this._dbContext);

				//Repository接口的实现统一在UnitOfWork中执行，
				var repositoryInstance = _serviceProvider.GetService(typeof(IRepository<TEntity>));

				if (repositoryInstance != null)
					this._repositories.Add(typeName, repositoryInstance);
			}

			return (IRepository<TEntity>)this._repositories[typeName];
		}

		public void SaveChanges()
		{
            if (_hasCommited)
                throw new InvalidOperationException("不能在一个工作单元中多次调用SaveChanges()方法，您应该总是在所有操作完成之后调用SaveChanges()");

            this._dbContext.SaveChanges();
            _hasCommited = true;
		}

		#endregion

		#region IDisposable 成员

		public void Dispose()
		{
			this.Dispose(true);

			GC.SuppressFinalize(this);
		}

		#endregion
	}
}

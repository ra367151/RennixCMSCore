using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RennixCMS.EntityFramework.DbContext;
using RennixCMS.Infrastructure.Data;
using RennixCMS.Infrastructure.Data.UnitOfWork;

namespace RennixCMS.EntityFramework.UnitOfWork
{
	public abstract class UnitOfWorkContextBase : IUnitOfWorkContext
	{

		public UnitOfWorkContextBase(ApplicationDbContext dbContext)
		{
			Context = dbContext;
		}

		/// <summary>
		/// 获取 当前使用的数据访问上下文对象
		/// </summary>
		protected ApplicationDbContext Context { get; private set; }

		/// <summary>
		///     获取 当前单元操作是否已被提交
		/// </summary>
		public bool IsCommitted { get; private set; }

		/// <summary>
		///     提交当前单元操作的结果
		/// </summary>
		/// <returns></returns>
		public int Commit()
		{
			if (IsCommitted)
			{
				return 0;
			}
			try
			{
				int result = Context.SaveChanges();
				IsCommitted = true;
				return result;
			}
			catch (DbUpdateException e)
			{
				if (e.InnerException != null && e.InnerException.InnerException is SqlException)
				{
					SqlException sqlEx = e.InnerException.InnerException as SqlException;
					throw sqlEx;
				}
				throw;
			}
		}

		public void Dispose()
		{
			if (!IsCommitted)
			{
				Commit();
			}
			Context.Dispose();
		}

		/// <summary>
		///   为指定的类型返回 System.Data.Entity.DbSet，这将允许对上下文中的给定实体执行 CRUD 操作。
		/// </summary>
		/// <typeparam name="TEntity"> 应为其返回一个集的实体类型。 </typeparam>
		/// <returns> 给定实体类型的 System.Data.Entity.DbSet 实例。 </returns>
		public DbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity
		{
			return Context.Set<TEntity>();
		}

		/// <summary>
		///     注册一个新的对象到仓储上下文中
		/// </summary>
		/// <typeparam name="TEntity"> 要注册的类型 </typeparam>
		/// <param name="entity"> 要注册的对象 </param>
		public void RegisterNew<TEntity>(TEntity entity) where TEntity : class, IEntity
		{
			EntityState state = Context.Entry(entity).State;
			if (state == EntityState.Detached)
			{
				Context.Entry(entity).State = EntityState.Added;
			}
			IsCommitted = false;
		}

		/// <summary>
		///     注册一个更改的对象到仓储上下文中
		/// </summary>
		/// <typeparam name="TEntity"> 要注册的类型 </typeparam>
		/// <param name="entity"> 要注册的对象 </param>
		public void RegisterModified<TEntity>(TEntity entity) where TEntity : class, IEntity
		{
			if (Context.Entry(entity).State == EntityState.Detached)
			{
				Context.Set<TEntity>().Attach(entity);
			}
			Context.Entry(entity).State = EntityState.Modified;
			IsCommitted = false;
		}

		/// <summary>
		///   注册一个删除的对象到仓储上下文中
		/// </summary>
		/// <typeparam name="TEntity"> 要注册的类型 </typeparam>
		/// <param name="entity"> 要注册的对象 </param>
		public void RegisterDeleted<TEntity>(TEntity entity) where TEntity : class, IEntity
		{
			Context.Entry(entity).State = EntityState.Deleted;
			IsCommitted = false;
		}
	}
}

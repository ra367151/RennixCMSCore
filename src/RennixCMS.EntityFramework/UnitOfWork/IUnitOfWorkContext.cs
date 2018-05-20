using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RennixCMS.Infrastructure.Data;
using RennixCMS.Infrastructure.Data.UnitOfWork;

namespace RennixCMS.EntityFramework.UnitOfWork
{
	public interface IUnitOfWorkContext : IUnitOfWork, IDisposable
	{
		/// <summary>
		///   为指定的类型返回 System.Data.Entity.DbSet，这将允许对上下文中的给定实体执行 CRUD 操作。
		/// </summary>
		/// <typeparam name="TEntity"> 应为其返回一个集的实体类型。 </typeparam>
		/// <returns> 给定实体类型的 System.Data.Entity.DbSet 实例。 </returns>
		DbSet<TEntity> Set<TEntity>() where TEntity : class,IEntity;

		/// <summary>
		///   注册一个新的对象到仓储上下文中
		/// </summary>
		/// <typeparam name="TEntity"> 要注册的类型 </typeparam>
		/// <param name="entity"> 要注册的对象 </param>
		void RegisterNew<TEntity>(TEntity entity) where TEntity : class, IEntity;

		/// <summary>
		///   注册一个更改的对象到仓储上下文中
		/// </summary>
		/// <typeparam name="TEntity"> 要注册的类型 </typeparam>
		/// <param name="entity"> 要注册的对象 </param>
		void RegisterModified<TEntity>(TEntity entity) where TEntity : class, IEntity;

		/// <summary>
		///   注册一个删除的对象到仓储上下文中
		/// </summary>
		/// <typeparam name="TEntity"> 要注册的类型 </typeparam>
		/// <param name="entity"> 要注册的对象 </param>
		void RegisterDeleted<TEntity>(TEntity entity) where TEntity : class, IEntity;

	}
}

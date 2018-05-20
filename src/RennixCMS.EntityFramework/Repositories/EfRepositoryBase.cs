using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RennixCMS.EntityFramework.DbContext;
using RennixCMS.EntityFramework.UnitOfWork;
using RennixCMS.Infrastructure.Data;
using RennixCMS.Infrastructure.Data.Repository;
using RennixCMS.Infrastructure.Extionsions;

namespace RennixCMS.EntityFramework.Repositories
{
	public class EfRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
	{
		public EfRepositoryBase(IUnitOfWorkContext dbContext)
		{
			UnitOfWorkDbContext = dbContext;
		}

		public IUnitOfWorkContext UnitOfWorkDbContext { get; set; }

		public DbSet<TEntity> Table => this.UnitOfWorkDbContext.Set<TEntity>();

		#region 仓储实现
		public virtual IQueryable<TEntity> GetAll()
		{
			return GetAllIncluding();
		}

		public virtual IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
		{
			var query = Table.AsQueryable();

			if (!propertySelectors.IsNullOrEmpty())
			{
				foreach (var propertySelector in propertySelectors)
				{
					query = query.Include(propertySelector);
				}
			}

			return query;
		}

		public virtual async Task<List<TEntity>> GetAllListAsync()
		{
			return await GetAll().ToListAsync();
		}

		public virtual async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await GetAll().Where(predicate).ToListAsync();
		}

		public virtual async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await GetAll().SingleAsync(predicate);
		}

		public virtual async Task<TEntity> FirstOrDefaultAsync(int id)
		{
			return await GetAll().FirstOrDefaultAsync(x => x.Id.Equals(id));
		}

		public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await GetAll().FirstOrDefaultAsync(predicate);
		}

		public virtual TEntity Insert(TEntity entity, bool isSave = true)
		{
			return Table.Add(entity).Entity;
		}

		public virtual async Task<TEntity> InsertAsync(TEntity entity, bool isSave = true)
		{
			Insert(entity);

			if (isSave)
				UnitOfWorkDbContext.Commit();

			return await Task.FromResult(entity);
		}

		public virtual TEntity Update(TEntity entity, bool isSave = true)
		{
			UnitOfWorkDbContext.RegisterModified(entity);

			if (isSave)
				UnitOfWorkDbContext.Commit();

			return entity;
		}

		public virtual async Task<TEntity> UpdateAsync(TEntity entity, bool isSave = true)
		{
			Update(entity);

			if (isSave)
				UnitOfWorkDbContext.Commit();

			return await Task.FromResult(entity);
		}

		public virtual void Delete(TEntity entity, bool isSave = true)
		{
			Delete(entity, isSave);
		}

		public virtual void Delete(int id, bool isSave = true)
		{
			var entity = FirstOrDefault(id);
			if (entity != null)
			{
				Delete(entity);
			}
		}

		public virtual TEntity FirstOrDefault(int id)
		{
			return GetAll().FirstOrDefault(x => x.Id.Equals(id));
		}

		public virtual async Task<int> CountAsync()
		{
			return await GetAll().CountAsync();
		}

		public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await GetAll().Where(predicate).CountAsync();
		}

		public async Task<long> LongCountAsync()
		{
			return await GetAll().LongCountAsync();
		}

		public async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await GetAll().Where(predicate).LongCountAsync();
		}

		public virtual TEntity Get(int id)
		{
			throw new NotImplementedException();
		}

		public virtual async Task<TEntity> GetAsync(int id)
		{
			return await Task.FromResult(Get(id));
		}

		public virtual TEntity Single(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().Single(predicate);
		}

		public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().FirstOrDefault(predicate);
		}

		public virtual TEntity FirstOrDefault()
		{
			return GetAll().FirstOrDefault();
		}

		public virtual async Task<TEntity> FirstOrDefaultAsync()
		{
			return await GetAll().FirstOrDefaultAsync();
		}

		public virtual List<TEntity> GetAllList()
		{
			return GetAll().ToList();
		}

		public virtual List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().Where(predicate).ToList();
		}

		public virtual async Task DeleteAsync(TEntity entity, bool isSave = true)
		{
			await DeleteAsync(x => x.Id.Equals(entity.Id));
		}

		public virtual async Task DeleteAsync(int id, bool isSave = true)
		{
			await DeleteAsync(x => x.Id.Equals(id));
		}

		public virtual void Delete(Expression<Func<TEntity, bool>> predicate, bool isSave = true)
		{
			foreach (var item in GetAll().Where(predicate))
			{
				UnitOfWorkDbContext.RegisterModified(item);
			}

			if (isSave)
				UnitOfWorkDbContext.Commit();
		}

		public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool isSave = true)
		{
			await Task.Factory.StartNew(() => Delete(predicate));
		}

		public virtual int Count()
		{
			return GetAll().Count();
		}

		public virtual int Count(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().Where(predicate).Count();
		}

		#endregion

	}
}

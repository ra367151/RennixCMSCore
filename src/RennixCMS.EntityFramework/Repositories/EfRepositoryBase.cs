using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RennixCMS.Infrastructure.Data;
using RennixCMS.Infrastructure.Data.Repository;
using RennixCMS.Infrastructure.Extionsions;

namespace RennixCMS.EntityFramework.Repositories
{
	public class EfRepositoryBase<TDbContext, TEntity, TPrimaryKey> :
		IRepository<TEntity, TPrimaryKey>
		where TEntity : class, IEntity<TPrimaryKey>
		where TDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public EfRepositoryBase(Func<TDbContext> dbContext)
		{
			Context = dbContext();
			Table = Context.Set<TEntity>();
		}

		public TDbContext Context { get; set; }

		public DbSet<TEntity> Table { get; set; }



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

		public virtual async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
		{
			return await GetAll().FirstOrDefaultAsync(x => x.Id.Equals(id));
		}

		public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await GetAll().FirstOrDefaultAsync(predicate);
		}

		public virtual TEntity Insert(TEntity entity)
		{
			return Table.Add(entity).Entity;
		}

		public virtual async Task<TEntity> InsertAsync(TEntity entity)
		{
			return await Task.FromResult(Insert(entity));
		}

		public virtual TPrimaryKey InsertAndGetId(TEntity entity)
		{
			entity = Insert(entity);

			if (entity.IsTransient())
			{
				Context.SaveChanges();
			}

			return entity.Id;
		}

		public virtual async Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
		{
			entity = await InsertAsync(entity);

			if (entity.IsTransient())
			{
				await Context.SaveChangesAsync();
			}

			return entity.Id;
		}



		public virtual TEntity Update(TEntity entity)
		{
			AttachIfNot(entity);
			Context.Entry(entity).State = EntityState.Modified;
			return entity;
		}

		public virtual async Task<TEntity> UpdateAsync(TEntity entity)
		{
			entity = Update(entity);
			return await Task.FromResult(entity);
		}

		public virtual void Delete(TEntity entity)
		{
			AttachIfNot(entity);
			Table.Remove(entity);
		}

		public virtual void Delete(TPrimaryKey id)
		{
			var entity = GetFromChangeTrackerOrNull(id);
			if (entity != null)
			{
				Delete(entity);
				return;
			}

			entity = FirstOrDefault(id);
			if (entity != null)
			{
				Delete(entity);
				return;
			}

			//Could not found the entity, do nothing.
		}

		public virtual TEntity FirstOrDefault(TPrimaryKey id)
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

		protected void AttachIfNot(TEntity entity)
		{
			var entry = Context.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
			if (entry != null)
			{
				return;
			}

			Table.Attach(entity);
		}

		private TEntity GetFromChangeTrackerOrNull(TPrimaryKey id)
		{
			var entry = Context.ChangeTracker.Entries()
				.FirstOrDefault(
					ent =>
						ent.Entity is TEntity &&
						EqualityComparer<TPrimaryKey>.Default.Equals(id, (ent.Entity as TEntity).Id)
				);

			return entry?.Entity as TEntity;
		}

		public virtual TEntity Get(TPrimaryKey id)
		{
			throw new NotImplementedException();
		}

		public virtual async Task<TEntity> GetAsync(TPrimaryKey id)
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

		public virtual List<TEntity> GetAllList()
		{
			return GetAll().ToList();
		}

		public virtual List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().Where(predicate).ToList();
		}

		public virtual async Task DeleteAsync(TEntity entity)
		{
			await DeleteAsync(x => x.Id.Equals(entity.Id));
		}

		public virtual async Task DeleteAsync(TPrimaryKey id)
		{
			await DeleteAsync(x => x.Id.Equals(id));
		}

		public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
		{
			foreach (var item in GetAll().Where(predicate))
			{
				Context.Set<TEntity>().Attach(item as TEntity);
				Context.Entry(item).State = EntityState.Deleted;
				Context.Set<TEntity>().Remove(item as TEntity);
			}
		}

		public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
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

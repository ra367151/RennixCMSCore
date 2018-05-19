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
		public IQueryable<TEntity> GetAll()
		{
			return GetAllIncluding();
		}

		public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
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

		public async Task<List<TEntity>> GetAllListAsync()
		{
			return await GetAll().ToListAsync();
		}

		public async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await GetAll().Where(predicate).ToListAsync();
		}

		public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await GetAll().SingleAsync(predicate);
		}

		public async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
		{
			return await GetAll().FirstOrDefaultAsync(x => x.Id.Equals(id));
		}

		public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await GetAll().FirstOrDefaultAsync(predicate);
		}

		public TEntity Insert(TEntity entity)
		{
			return Table.Add(entity).Entity;
		}

		public Task<TEntity> InsertAsync(TEntity entity)
		{
			return Task.FromResult(Insert(entity));
		}

		public TPrimaryKey InsertAndGetId(TEntity entity)
		{
			entity = Insert(entity);

			if (entity.IsTransient())
			{
				Context.SaveChanges();
			}

			return entity.Id;
		}

		public async Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
		{
			entity = await InsertAsync(entity);

			if (entity.IsTransient())
			{
				await Context.SaveChangesAsync();
			}

			return entity.Id;
		}

		public TPrimaryKey InsertOrUpdateAndGetId(TEntity entity)
		{
			entity = InsertOrUpdate(entity);

			if (entity.IsTransient())
			{
				Context.SaveChanges();
			}

			return entity.Id;
		}

		private TEntity InsertOrUpdate(TEntity entity)
		{
			throw new NotImplementedException();
		}

		public async Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity)
		{
			entity = await InsertOrUpdateAsync(entity);

			if (entity.IsTransient())
			{
				await Context.SaveChangesAsync();
			}

			return entity.Id;
		}

		private Task<TEntity> InsertOrUpdateAsync(TEntity entity)
		{
			throw new NotImplementedException();
		}

		public TEntity Update(TEntity entity)
		{
			AttachIfNot(entity);
			Context.Entry(entity).State = EntityState.Modified;
			return entity;
		}

		public Task<TEntity> UpdateAsync(TEntity entity)
		{
			entity = Update(entity);
			return Task.FromResult(entity);
		}

		public void Delete(TEntity entity)
		{
			AttachIfNot(entity);
			Table.Remove(entity);
		}

		public void Delete(TPrimaryKey id)
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

		private TEntity FirstOrDefault(TPrimaryKey id)
		{
			return GetAll().FirstOrDefault(x => x.Id.Equals(id));
		}

		public async Task<int> CountAsync()
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

		public Task EnsureCollectionLoadedAsync<TProperty>(
			TEntity entity,
			Expression<Func<TEntity, IEnumerable<TProperty>>> collectionExpression,
			CancellationToken cancellationToken)
			where TProperty : class
		{
			return Context.Entry(entity).Collection(collectionExpression).LoadAsync(cancellationToken);
		}

		public Task EnsurePropertyLoadedAsync<TProperty>(
			TEntity entity,
			Expression<Func<TEntity, TProperty>> propertyExpression,
			CancellationToken cancellationToken)
			where TProperty : class
		{
			return Context.Entry(entity).Reference(propertyExpression).LoadAsync(cancellationToken);
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

		public TEntity Get(TPrimaryKey id)
		{
			throw new NotImplementedException();
		}

		public Task<TEntity> GetAsync(TPrimaryKey id)
		{
			throw new NotImplementedException();
		}

		public TEntity Single(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().Single(predicate);
		}

		TEntity IRepository<TEntity, TPrimaryKey>.FirstOrDefault(TPrimaryKey id)
		{
			throw new NotImplementedException();
		}

		public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public TEntity Load(TPrimaryKey id)
		{
			throw new NotImplementedException();
		}

		public List<TEntity> GetAllList()
		{
			throw new NotImplementedException();
		}

		public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		TEntity IRepository<TEntity, TPrimaryKey>.InsertOrUpdate(TEntity entity)
		{
			throw new NotImplementedException();
		}

		Task<TEntity> IRepository<TEntity, TPrimaryKey>.InsertOrUpdateAsync(TEntity entity)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(TEntity entity)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(TPrimaryKey id)
		{
			throw new NotImplementedException();
		}

		public void Delete(Expression<Func<TEntity, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public int Count()
		{
			throw new NotImplementedException();
		}

		public int Count(Expression<Func<TEntity, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public long LongCount()
		{
			throw new NotImplementedException();
		}

		public long LongCount(Expression<Func<TEntity, bool>> predicate)
		{
			throw new NotImplementedException();
		}
		#endregion

	}
}

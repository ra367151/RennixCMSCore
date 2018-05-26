using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RennixCMS.Infrastructure.Data.Repository
{
	/// <summary>
	/// 仓储规范
	/// </summary>
	/// <typeparam name="TEntity">实现或者间接实现IEntity的实体类型</typeparam>
	public interface IRepository<TEntity> where TEntity : class, IEntity
	{
		#region 取得单一实体
		TEntity Get(int id);
		Task<TEntity> GetAsync(int id);
		TEntity Single(Expression<Func<TEntity, bool>> predicate);
		TEntity FirstOrDefault(int id);
		Task<TEntity> FirstOrDefaultAsync(int id);
		TEntity FirstOrDefault();
		Task<TEntity> FirstOrDefaultAsync();
		TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
		Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

		#endregion

		#region 获取实体列表
		List<TEntity> GetAllList();
		Task<List<TEntity>> GetAllListAsync();
		List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);
		Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);
		IQueryable<TEntity> GetAll();
		#endregion

		#region 插入实体
		TEntity Insert(TEntity entity);
		Task<TEntity> InsertAsync(TEntity entity);
		#endregion

		#region 更新实体
		TEntity Update(TEntity entity);
		Task<TEntity> UpdateAsync(TEntity entity );
		#endregion

		#region 删除实体
		void Delete(TEntity entity );
		Task DeleteAsync(TEntity entity );
		void Delete(int id );
		Task DeleteAsync(int id );
		void Delete(Expression<Func<TEntity, bool>> predicate );
		Task DeleteAsync(Expression<Func<TEntity, bool>> predicate );
		#endregion

		#region 其他方法
		int Count();
		Task<int> CountAsync();
		int Count(Expression<Func<TEntity, bool>> predicate);
		Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
		Task<long> LongCountAsync();
		Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate);
		#endregion
	}
}

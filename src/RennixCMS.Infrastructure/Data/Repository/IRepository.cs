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
		TEntity Insert(TEntity entity, bool isSave = true);
		Task<TEntity> InsertAsync(TEntity entity, bool isSave = true);
		#endregion

		#region 更新实体
		TEntity Update(TEntity entity, bool isSave = true);
		Task<TEntity> UpdateAsync(TEntity entity, bool isSave = true);
		#endregion

		#region 删除实体
		void Delete(TEntity entity, bool isSave = true);
		Task DeleteAsync(TEntity entity, bool isSave = true);
		void Delete(int id, bool isSave = true);
		Task DeleteAsync(int id, bool isSave = true);
		void Delete(Expression<Func<TEntity, bool>> predicate, bool isSave = true);
		Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool isSave = true);
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

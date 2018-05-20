using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Data.UnitOfWork
{
	public interface IUnitOfWork
	{
		/// <summary>
		/// 获取 当前单元操作是否已被提交
		/// </summary>
		/// <returns></returns>
		bool IsCommitted { get; }

		/// <summary>
		/// 提交当前单元操作的结果
		/// </summary>
		/// <returns></returns>
		int Commit();

	}
}

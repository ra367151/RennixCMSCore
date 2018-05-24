using Microsoft.Extensions.Logging;
using RennixCMS.Infrastructure.Data;
using RennixCMS.Infrastructure.Data.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.ApplicationService
{
    public interface IApplicationService
    {
        /// <summary>
        /// 日志组件
        /// </summary>
        ILogger Logger { get; }

        /// <summary>
        /// 将实体映射为Dto
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        TDto MapToDto<TDto, TEntity>(TEntity entity)
            where TEntity : class, IEntity
            where TDto : class, IDto;

        /// <summary>
        /// dto转换为实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity MapToEntity<TEntity, TDto>(TDto entity)
            where TEntity : class, IEntity
            where TDto : class, IDto;

    }
}

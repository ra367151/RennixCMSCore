using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Logging;
using RennixCMS.Infrastructure.Data;
using RennixCMS.Infrastructure.Data.Dto;

namespace RennixCMS.Infrastructure.ApplicationService
{
    public abstract class ApplicationService : IApplicationService
    {
        private IMapper _mapper;
        private IServiceProvider _serviceProvider;

        public ApplicationService(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
            this.Initialize();
        }

        public ILogger Logger { get; private set; }

        public TDto MapToDto<TDto, TEntity>(TEntity entity)
            where TDto : class, IDto
            where TEntity : class, IEntity
        {
            return _mapper.Map<TDto>(entity);
        }

        public TEntity MapToEntity<TEntity, TDto>(TDto entity)
            where TDto : class, IDto
            where TEntity : class, IEntity
        {
            return _mapper.Map<TEntity>(entity);
        }

        private void Initialize()
        {
            this.Logger = (ILogger)_serviceProvider.GetService(typeof(ILogger));
            this._mapper = (IMapper)_serviceProvider.GetService(typeof(IMapper));
        }
    }
}

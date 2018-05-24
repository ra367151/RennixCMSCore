using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<TDto> MapToDtoAsync<TDto>(object entity)
            where TDto : class, IDto
        {
            return await Task.FromResult(_mapper.Map<TDto>(entity));
        }

        public async Task<TEntity> MapToEntityAsync<TEntity>(object dto)
            where TEntity : class, IEntity
        {
            return await Task.FromResult(_mapper.Map<TEntity>(dto));
        }

        private void Initialize()
        {
            this.Logger = (ILogger)_serviceProvider.GetService(typeof(ILogger));
            this._mapper = (IMapper)_serviceProvider.GetService(typeof(IMapper));
        }
    }
}

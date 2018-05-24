using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Data.UnitOfWork
{
    public class DefaultUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public DefaultUnitOfWorkFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IUnitOfWork CreateScope()
        {
            return (IUnitOfWork)_serviceProvider.GetService(typeof(IUnitOfWork));
        }
    }
}

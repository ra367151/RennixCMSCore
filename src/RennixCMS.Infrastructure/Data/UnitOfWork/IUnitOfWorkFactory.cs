using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Data.UnitOfWork
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork CreateScope();
    }
}

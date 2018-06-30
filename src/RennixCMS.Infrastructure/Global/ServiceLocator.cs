using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Global
{
    public static class ServiceLocator
    {
        public static IServiceProvider Instance { get; set; }
    }
}

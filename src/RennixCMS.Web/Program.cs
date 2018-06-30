using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RennixCMS.Application.Setting;
using RennixCMS.Infrastructure.Global;
using RennixCMS.Infrastructure.Mvc;

namespace RennixCMS.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            host.Run();
        }


        public static IWebHost BuildWebHost(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder(args)
                       .UseStartup<Startup>()
                       .Build();

            return host;
        }
    }
}

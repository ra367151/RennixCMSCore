using RennixCMS.Infrastructure.ApplicationService;
using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Application.Content
{
    public class PageAppService : ApplicationService, IPageAppService
    {
        public PageAppService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Console.WriteLine("PageAppService构造函数");
        }

        public void Test()
        {
            var dto = new MapDto { Id = 1, Name = "sss" };
            var res = MapToEntity<Map, MapDto>(dto);
            Console.WriteLine("PageAppService Test函数");
        }
    }
}

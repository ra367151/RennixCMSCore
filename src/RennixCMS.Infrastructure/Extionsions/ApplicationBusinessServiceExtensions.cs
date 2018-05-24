using Microsoft.Extensions.DependencyInjection;
using RennixCMS.Infrastructure.ApplicationService;
using RennixCMS.Infrastructure.DomService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RennixCMS.Infrastructure.Extionsions
{
    public static class ApplicationBusinessServiceExtensions
    {
        private static List<KeyValuePair<Type, Type>> allTypes;

        static ApplicationBusinessServiceExtensions()
        {
            var cacheTypes = Assembly
                     .GetEntryAssembly()
                     .GetReferencedAssemblies()
                     .Select(Assembly.Load)
                     .SelectMany(x => x.DefinedTypes)
                     .Where(x => x.IsPublic && !x.IsAbstract && !x.IsInterface)
                     .Where(type =>
                        typeof(IApplicationService).GetTypeInfo().IsAssignableFrom(type.AsType())
                        || typeof(IDomService).GetTypeInfo().IsAssignableFrom(type.AsType()))
                     .Select(x => new
                     {
                         interfaceType = x.GetInterfaces().FirstOrDefault(i => i.Name.ToLower().EndsWith("appservice")),
                         implementType = x.AsType()
                     })
                     .Where(x => x.interfaceType != null)
                     .ToList();

            allTypes = new List<KeyValuePair<Type, Type>>();
            foreach (var type in cacheTypes)
            {
                allTypes.Add(new KeyValuePair<Type, Type>(type.interfaceType, type.implementType));
            }
        }

        /// <summary>
        /// 注册AppService
        /// </summary>
        /// <param name="services"></param>
        /// <param name="endWith"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterAppServices(this IServiceCollection services, string endWith = "appservice")
        {
            foreach (var type in allTypes.Where(x => x.Value.Name.ToLower().EndsWith(endWith)))
            {
                services.AddScoped(type.Key, type.Value);
            }
            return services;
        }

        /// <summary>
        /// 注册DomService
        /// </summary>
        /// <param name="services"></param>
        /// <param name="endWith"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterDomServices(this IServiceCollection services, string endWith = "domservice")
        {
            foreach (var type in allTypes.Where(x => x.Value.Name.ToLower().EndsWith(endWith)))
            {
                services.AddScoped(type.Key, type.Value);
            }
            return services;
        }
    }
}

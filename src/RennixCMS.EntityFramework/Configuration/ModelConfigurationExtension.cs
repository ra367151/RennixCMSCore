using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RennixCMS.Domain.Identity.Role.Models;
using RennixCMS.Domain.Identity.RoleClaim.Models;
using RennixCMS.Domain.Identity.User.Models;
using RennixCMS.Domain.Identity.UserClaim.Models;
using RennixCMS.Domain.Identity.UserLogin.Models;
using RennixCMS.Domain.Identity.UserRole.Models;
using RennixCMS.Domain.Identity.UserToken.Models;

namespace RennixCMS.EntityFramework.Configuration
{
	public static class ModelConfigurationExtension
	{
		/// <summary>
		/// 从映射配置中自动装配继承了ModelConfiguration，实现模型映射的配置
		/// </summary>
		/// <param name="builder"></param>
		public static void LoadAllFromFluentApi(this ModelBuilder builder)
		{
			var types = new List<Type>();

			foreach (AssemblyName item in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
			{
				types.AddRange(Assembly.Load(item).GetTypes());
			}

			var configurationTypes = types.Where(x => x.IsPublic
								&& !x.IsAbstract
								&& !x.IsInterface
								&& x.BaseType.IsGenericType
								&& x.BaseType.GetGenericTypeDefinition() == typeof(ModelConfiguration<>))
								.ToList();

			foreach (var type in configurationTypes)
			{
				dynamic configurationInstance = Activator.CreateInstance(type);
				builder.ApplyConfiguration(configurationInstance);
			}
		}

		/// <summary>
		/// 删除Indentity相关表表名的“AspNet”前缀
		/// </summary>
		/// <param name="builder"></param>
		public static void RemoveAspNetPrefixForIdentity(this ModelBuilder builder)
		{
			builder.Entity<User>().ToTable("User");
			builder.Entity<Role>().ToTable("Role");
			builder.Entity<RoleClaim>().ToTable("RoleClaim");
			builder.Entity<UserClaim>().ToTable("UserClaim");
			builder.Entity<UserRole>().ToTable("UserRole");
			builder.Entity<UserToken>().ToTable("UserToken");
			builder.Entity<UserLogin>().ToTable("UserLogin");
		}
	}
}

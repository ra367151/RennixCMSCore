using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RennixCMS.Web.Models;
using RennixCMS.Web.Services;
using RennixCMS.EntityFramework.DbContext;
using RennixCMS.Domain.Identity.User.Models;
using RennixCMS.Domain.Identity.Role.Models;
using RennixCMS.Infrastructure.Data.Repository;
using RennixCMS.EntityFramework.Repositories;
using RennixCMS.Infrastructure.Data.UnitOfWork;
using RennixCMS.EntityFramework.UnitOfWork;
using Microsoft.Extensions.Logging;
using RennixCMS.Infrastructure.Extionsions;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using Microsoft.Extensions.Options;
using RennixCMS.Infrastructure.WebApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RennixCMS.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            // 数据库上下文
            services.AddScoped(typeof(ApplicationDbContextBase), typeof(ApplicationDbContext));
			// 数据仓储
			services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
			// 工作单元
			services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
			// 工作单元工厂
			services.AddScoped(typeof(IUnitOfWorkFactory), typeof(DefaultUnitOfWorkFactory));

			services.AddDbContext<ApplicationDbContextBase>(options =>
				options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("RennixCMS")));

			services.AddIdentity<User, Role>()
				.AddEntityFrameworkStores<ApplicationDbContextBase>()
				.AddDefaultTokenProviders();

			// Add application services.
			services.AddTransient<IEmailSender, EmailSender>();

			// 注册domservice
			services.RegisterDomServices();
			// 注册appservice
			services.RegisterAppServices();

			services.AddAutoMapper();

			services.AddMvc(options =>
			{
				
			})
			.AddJsonOptions(options =>
			{
					options.SerializerSettings.DateFormatString = "yyyy/MM/dd hh:mm:ss";
			})
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new Info() { Title = "Swagger Test UI", Version = "v1" });
				options.CustomSchemaIds(type => type.FullName); // 解决相同类名会报错的问题
				options.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SwaggerUI.xml")); // 标注要使用的 XML 文档
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }


            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseSwagger();
			// 在这里面可以注入
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "HKERP API V1");
			});

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
				  name: "default",
				  template: "{controller=Home}/{action=Index}/{id?}"
				);

            // 区域路由
            routes.MapAreaRoute(
               name: "areas",
               areaName: "Admin",
               template: "{admin}/{controller}/{action}/{id?}",
               defaults :new
               {
                   area ="admin",
                   controller ="home",
                   action ="index"}
			   );
			});
		}
	}
}

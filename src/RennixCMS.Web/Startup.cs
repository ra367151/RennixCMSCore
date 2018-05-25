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
            // 数据库上下文
            services.AddScoped(typeof(ApplicationDbContextBase), typeof(ApplicationDbContext));
            // 数据仓储
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            // 工作单元
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            // 工作单元工厂
            services.AddScoped(typeof(IUnitOfWorkFactory), typeof(DefaultUnitOfWorkFactory));

            services.AddDbContext<ApplicationDbContextBase>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RennixCMS")));

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

            services.AddMvc();

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
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

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
                   template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
               );
            });
        }
    }
}

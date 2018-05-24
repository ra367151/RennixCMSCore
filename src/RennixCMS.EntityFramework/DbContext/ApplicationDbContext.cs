using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RennixCMS.Domain.Category.Models;
using RennixCMS.Domain.Comment.Models;
using RennixCMS.Domain.Identity.Role.Models;
using RennixCMS.Domain.Identity.RoleClaim.Models;
using RennixCMS.Domain.Identity.User.Models;
using RennixCMS.Domain.Identity.UserClaim.Models;
using RennixCMS.Domain.Identity.UserLogin.Models;
using RennixCMS.Domain.Identity.UserRole.Models;
using RennixCMS.Domain.Identity.UserToken.Models;
using RennixCMS.EntityFramework.Configuration;

namespace RennixCMS.EntityFramework.DbContext
{
	//TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken> : IdentityUserContext<TUser, TKey, TUserClaim, TUserLogin, TUserToken
	public class ApplicationDbContext : ApplicationDbContextBase
	{
		public ApplicationDbContext(DbContextOptions options)
			:base(options)
		{
			
		}

		public DbSet<Comment> Comment { get; set; }

		public DbSet<Domain.Post.Models.Post> Post { get; set; }

		public DbSet<Category> Category { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.LoadAllFromFluentApi();

			builder.RemoveAspNetPrefixForIdentity();
		}
	}
}

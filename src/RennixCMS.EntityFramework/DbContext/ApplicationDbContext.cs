using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
	public class ApplicationDbContext :
		IdentityDbContext<User, Role, Guid,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			:base(options)
		{
			
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.LoadAllFromFluentApi();

			builder.RemoveAspNetPrefixForIdentity();
		}
	}
}

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

namespace RennixCMS.EntityFramework.DbContext
{
	/// <summary>
	/// 应用程序数据库上下文
	/// </summary>
	public abstract class ApplicationDbContextBase :
		IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
	{
		public ApplicationDbContextBase(DbContextOptions options) : base(options)
		{
            
		}
	}
}

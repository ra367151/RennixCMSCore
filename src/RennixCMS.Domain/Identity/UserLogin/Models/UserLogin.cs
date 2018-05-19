using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using RennixCMS.Infrastructure.Data;

namespace RennixCMS.Domain.Identity.UserLogin.Models
{
	public class UserLogin : IdentityUserLogin<int>, IEntity
	{
		public int Id { get; set; }
	}
}

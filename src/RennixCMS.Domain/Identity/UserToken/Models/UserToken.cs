using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using RennixCMS.Infrastructure.Data;

namespace RennixCMS.Domain.Identity.UserToken.Models
{
	public class UserToken : IdentityUserToken<int>, IEntity
	{
		public int Id { get; set; }
	}
}

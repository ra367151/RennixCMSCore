using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using RennixCMS.Infrastructure.Data;

namespace RennixCMS.Domain.Identity.UserClaim.Models
{
	public class UserClaim : IdentityUserClaim<Guid>, IEntity<Guid>
	{
		public Guid Id { get; set; }
	}
}

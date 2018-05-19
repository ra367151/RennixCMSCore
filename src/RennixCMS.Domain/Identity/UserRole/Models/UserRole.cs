using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using RennixCMS.Infrastructure.Data;

namespace RennixCMS.Domain.Identity.UserRole.Models
{
	public class UserRole : IdentityUserRole<Guid>, IEntity<Guid>
	{
		public Guid Id { get; set; }
	}
}

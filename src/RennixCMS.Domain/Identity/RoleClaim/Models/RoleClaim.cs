using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using RennixCMS.Infrastructure.Data;

namespace RennixCMS.Domain.Identity.RoleClaim.Models
{
	public class RoleClaim : IdentityRoleClaim<Guid>, IEntity<Guid>
	{
		 public Guid Id { get; set; }
	}
}

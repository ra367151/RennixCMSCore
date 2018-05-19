using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using RennixCMS.Infrastructure.Data;

namespace RennixCMS.Domain.Identity.UserToken.Models
{
	public class UserToken : IdentityUserToken<Guid>, IEntity<Guid>
	{
		public Guid Id { get; set; }
	}
}

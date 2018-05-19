using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using RennixCMS.Infrastructure.Data;

namespace RennixCMS.Domain.Identity.User.Models
{
	public class User : IdentityUser<int>, IEntity
	{

	}
}

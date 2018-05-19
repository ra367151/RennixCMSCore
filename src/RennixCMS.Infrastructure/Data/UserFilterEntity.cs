using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Data
{
	public class UserFilterEntity : IUserFilterEntity
	{
		public Guid UserId { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Infrastructure.Data
{
	public class UserFilterEntity : IUserFilterEntity
	{
		public int UserId { get; set; }
		public int Id { get; set; }
	}
}

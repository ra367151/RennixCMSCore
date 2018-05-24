using System;
using System.Collections.Generic;
using System.Text;
using RennixCMS.Infrastructure.Data;

namespace RennixCMS.Domain.Category.Models
{
    public class Category:IEntity
    {
		public int Id { get; set; }

		public int ParentId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

	}
}

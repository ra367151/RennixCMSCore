﻿using System;
using System.Collections.Generic;
using System.Text;
using RennixCMS.Infrastructure.Data;
using RennixCMS.Infrastructure.Data.Dto;

namespace RennixCMS.Domain.Category.Dtos
{
    public class CreateCategoryDto:IDto
    {
		public int ParentId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public void ValidateProperties()
		{
			
		}
	}
}

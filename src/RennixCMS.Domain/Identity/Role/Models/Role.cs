using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;
using RennixCMS.Infrastructure.Data;

namespace RennixCMS.Domain.Identity.Role.Models
{
    public class Role:IdentityRole<Guid>, IEntity
	{
		
    }
}

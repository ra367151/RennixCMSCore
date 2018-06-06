using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RennixCMS.Web.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Account { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}

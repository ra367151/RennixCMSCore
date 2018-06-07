using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.WebApi.ViewModels.Account
{
    public class LoginResultDto
    {
        public LoginResultDto(string returnUrl)
        {
            this.RedirectToUrl = returnUrl;
        }
        public string RedirectToUrl { get; set; }
    }
}

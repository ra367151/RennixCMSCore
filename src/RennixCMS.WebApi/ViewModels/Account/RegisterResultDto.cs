using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.WebApi.ViewModels.Account
{
    public class RegisterResultDto
    {
        public RegisterResultDto(string returnUrl)
        {
            this.RedirectToUrl = returnUrl;
        }

        /// <summary>
        /// 注册成功的跳转地址
        /// </summary>
        public string RedirectToUrl { get; set; }
    }
}

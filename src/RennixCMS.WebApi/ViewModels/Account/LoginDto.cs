using RennixCMS.Infrastructure.Data.Dto;
using RennixCMS.Infrastructure.Extionsions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RennixCMS.WebApi.ViewModels.Account
{
    public class LoginDto : IDto
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }

        public void ValidateProperties()
        {
            if (Email.IsNullOrEmpty())
                throw new RennixCMS.Infrastructure.Exceptions.RennixException($"{nameof(Email)}是必须的");

            if (!new Regex(@"^[A-Za-z0-9\u4e00-\u9fa5]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$").IsMatch(Email))
                throw new RennixCMS.Infrastructure.Exceptions.RennixException($"{nameof(Email)}格式不正确");

            if (Password.IsNullOrEmpty())
                throw new RennixCMS.Infrastructure.Exceptions.RennixException($"{nameof(Password)}是必须的");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RennixCMS.Domain.Identity.User.Models;
using RennixCMS.Infrastructure.Exceptions;
using RennixCMS.Infrastructure.WebApi;
using RennixCMS.WebApi.ViewModels;
using RennixCMS.WebApi.ViewModels.Account;

namespace RennixCMS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [WrapWebApiException]
    public class AccountController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signManager)
        {
            _userManager = userManager;
            _signInManager = signManager;
        }

        [HttpPost]
        public async Task<ResponseResult<LoginResultDto>> Login(LoginDto dto)
        {
            dto.ValidateProperties();

            var signResult = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, !dto.RememberMe, false);

            if (signResult.IsLockedOut)
                throw new RennixCMS.Infrastructure.Exceptions.RennixException("账号已被锁定");

            if (!signResult.Succeeded)
                throw new RennixCMS.Infrastructure.Exceptions.RennixException("账号或密码错误");

            // 验证url合法性 只能跳转到合法的地址
            if (CheckRedirectUrl(dto.ReturnUrl))
            {
                return ResponseResult.Create(new LoginResultDto(dto.ReturnUrl));
            }
            return ResponseResult.Create(new LoginResultDto("/"));
        }

        [HttpGet]
        public async Task<ResponseResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return ResponseResult.CreateVoidResult();
        }

        [HttpPost]
        public async Task<ResponseResult<RegisterResultDto>> Register(RegisterDto dto)
        {
            dto.ValidateProperties();

            var user = new User { UserName = dto.Email, Email = dto.Email };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                // 发送账号激活邮件
                // var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                await _signInManager.SignInAsync(user, isPersistent: false);

                if (CheckRedirectUrl(dto.ReturnUrl))
                {
                    return ResponseResult.Create(new RegisterResultDto(dto.ReturnUrl));
                }
                return ResponseResult.Create(new RegisterResultDto("/"));
            }
            else
            {
                var err = result.Errors.FirstOrDefault()?.Description;
                throw new RennixException($"注册失败,{err}");
            }
        }

        private bool CheckRedirectUrl(string returnUrl)
        {
            return true;
        }
    }
}
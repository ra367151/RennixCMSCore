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
using RennixCMS.Infrastructure.WebApi;
using RennixCMS.WebApi.ViewModels;

namespace RennixCMS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [WrapWebApiException]
    public class AccountController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager,SignInManager<User> signManager)
        {
            _userManager = userManager;
            _signInManager = signManager;
        }

        [HttpPost]
        public async Task<ResponseResult<LoginResult>> Login(LoginViewModel dto)
        {
            var signResult = await _signInManager.PasswordSignInAsync(dto.Account,dto.Password,!dto.RememberMe,false);
            
            if(signResult.IsLockedOut)
                throw new RennixCMS.Infrastructure.Exceptions.RennixException("账号已被锁定");

            if(!signResult.Succeeded)
                throw new RennixCMS.Infrastructure.Exceptions.RennixException("账号或密码错误");

            // 验证url合法性 只能跳转到合法的地址
            if(CheckRedirectUrl(dto.ReturnUrl))
            {
               return  ResponseResult.Create(new LoginResult(dto.ReturnUrl));
            }
            return ResponseResult.Create(new LoginResult("/"));
        }

        [HttpGet]
        public async Task<ResponseResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return ResponseResult.CreateVoidResult();
        }

        [HttpPost]
        public async Task<ResponseResult> Register()
        {
            return ResponseResult.CreateVoidResult();
        }

        private bool CheckRedirectUrl(string returnUrl)
        {
            return true;
        }
    }
}
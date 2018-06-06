using RennixCMS.Infrastructure.Data.Dto;

namespace RennixCMS.WebApi.ViewModels
{
    public class LoginViewModel:IDto
    {
        public string Account{get;set;}
        public string Password{get;set;}
        public bool RememberMe{get;set;}

        public string ReturnUrl{get;set;}
        
        public bool ValidateProperties()
        {
            return true;
        }
    }

    public class LoginResult
    {
        public LoginResult(string returnUrl)
        {
            this.RedirectToUrl = returnUrl;
        }
        public string RedirectToUrl {get;set;}
    }
}
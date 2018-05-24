using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RennixCMS.Domain.Identity.RoleClaim.Models;
using RennixCMS.Domain.Identity.User.Models;
using RennixCMS.Domain.Identity.UserLogin.Models;
using RennixCMS.Infrastructure.Data.Repository;
using RennixCMS.Infrastructure.Data.UnitOfWork;
using RennixCMS.Web.Models;

namespace RennixCMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public HomeController(IUnitOfWorkFactory unitOfWorkFactory)
		{
            _unitOfWorkFactory = unitOfWorkFactory;
		}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

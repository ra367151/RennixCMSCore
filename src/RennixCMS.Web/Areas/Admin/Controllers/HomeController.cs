using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RennixCMS.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminAreaController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
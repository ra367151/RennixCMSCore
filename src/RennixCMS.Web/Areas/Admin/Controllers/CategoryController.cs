using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RennixCMS.Web.Areas.Admin.Controllers
{
    [Route("[area]/[controller]/[action]")]
    public class CategoryController : AdminAreaController
    {
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RennixCMS.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("[area]/[controller]/[action]")]
    public class PostController : AdminAreaController
    {
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }
    }
}
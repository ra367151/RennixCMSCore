using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RennixCMS.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]/[action]")]
    public class PostController : Controller
    {
        [HttpGet]
        public IActionResult Preview(int id)
        {
            return View();
        }
    }
}
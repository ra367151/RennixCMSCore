using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RennixCMS.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// Admin区域控制器基类
    /// </summary>
    [Area("admin")]
    [Authorize]
    //[Authorize(Roles = "Administrator")]
    public abstract class AdminAreaController : Controller
    {

    }
}
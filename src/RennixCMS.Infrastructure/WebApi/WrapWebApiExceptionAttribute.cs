using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RennixCMS.Infrastructure.WebApi
{
	/// <summary>
	/// 包装WebAPI的异常 返回通用的异常结果
	/// </summary>
	public class WrapWebApiExceptionAttribute : ExceptionFilterAttribute,IExceptionFilter
	{
		public override void OnException(ExceptionContext context)
		{
			var ex = context.Exception;

			var response = ResponseResult.CreateExceptionResult(ex);

			context.Result = new JsonResult(response);

			context.HttpContext.Response.StatusCode = 500;
		}
	}
}

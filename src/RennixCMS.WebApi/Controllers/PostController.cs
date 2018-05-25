using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using RennixCMS.Domain.Post.Dtos;

namespace RennixCMS.WebApi.Controllers
{
	[Route("api/post")]
	public class PostController : Controller
	{
		/// <summary>
		/// /获取一个文章
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public PostDto Get(int id)
		{
			return new PostDto
			{
				CategoryId = 1,
				Author = "hello"
			};
		}
	}
}

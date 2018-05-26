using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RennixCMS.Application.Post;
using RennixCMS.Domain.Post.Dtos;
using RennixCMS.Infrastructure.Data;
using RennixCMS.Infrastructure.WebApi;

namespace RennixCMS.WebApi.Controllers
{
	/// <summary>
	/// 档案
	/// </summary>
	[Route("api/post")]
	[WrapWebApiException]
	public class PostController : Controller
	{
		private readonly IPostAppService _postAppService;
		public PostController(IPostAppService postAppService)
		{
			_postAppService = postAppService;
		}

		/// <summary>
		/// /获取一个档案
		/// </summary>
		/// <param name="id">档案id</param>
		/// <returns></returns>
		[HttpGet]
		[Route("{id}")]
		public async Task<ResponseResult<PostDto>> Get(int id)
		{
			return ResponseResult<PostDto>.Create(await _postAppService.GetPostAsync(id));
		}

		[HttpPost]
		[Route("list")]
		public async Task<ResponseResult<PageResult<PostDto>>> GetPostList(PostFilterDto dto)
		{
			return ResponseResult<PostDto>.Create(await _postAppService.GetListAsync(dto));
		}
	}
}

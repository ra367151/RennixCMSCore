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

		[HttpPost]
		[Route("ChangeVisiableState")]
		public async Task<ResponseResult> ChangeVisiableStateAsync(int id, bool isVisiable)
		{
			await _postAppService.ChangeVisiableStateAsync(id, isVisiable);
			return ResponseResult.CreateVoidResult();
		}

		[HttpGet]
		[Route("Count")]
		public async Task<ResponseResult<int>> CountAsync()
		{
			return ResponseResult.Create(await _postAppService.CountAsync());
		}

		[HttpPost]
		[Route("Create")]
		public async Task<ResponseResult<PostDto>> CreatePostAsync(CreatePostDto dto)
		{
			return ResponseResult.Create(await _postAppService.CreatePostAsync(dto));
		}

		[HttpPost]
		[Route("Delete/{id}")]
		public async Task<ResponseResult> DeletePostAsync(int id)
		{
			await _postAppService.DeletePostAsync(id);
			return ResponseResult.CreateVoidResult();
		}

		[HttpPost]
		[Route("List")]
		public async Task<ResponseResult<PageResult<PostDto>>> GetListAsync(PostFilterDto dto)
		{
			return ResponseResult.Create(await _postAppService.GetListAsync(dto));
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ResponseResult<PostDto>> GetPostAsync(int id)
		{
			return ResponseResult.Create(await _postAppService.GetPostAsync(id));
		}

		[HttpPost]
		[Route("Update")]
		public async Task<ResponseResult> UpdatePostAsync(UpdatePostDto dto)
		{
			await _postAppService.UpdatePostAsync(dto);
			return ResponseResult.CreateVoidResult();
		}
	}
}

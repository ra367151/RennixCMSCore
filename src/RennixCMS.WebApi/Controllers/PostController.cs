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
    [Route("api/[controller]/[action]")]
    [WrapWebApiException]
    public class PostController : Controller
    {
        private readonly IPostAppService _postAppService;
        public PostController(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }

        [HttpPost]
        public async Task<ResponseResult> ChangeVisiableState(int id, bool isVisiable)
        {
            await _postAppService.ChangeVisiableStateAsync(id, isVisiable);
            return ResponseResult.CreateVoidResult();
        }

        [HttpGet]
        public async Task<ResponseResult<int>> Count()
        {
            return ResponseResult.Create(await _postAppService.CountAsync());
        }

        [HttpPost]
        public async Task<ResponseResult<PostDto>> CreatePost(CreatePostDto dto)
        {
            return ResponseResult.Create(await _postAppService.CreatePostAsync(dto));
        }

        [HttpPost]
        public async Task<ResponseResult> DeletePost(int id)
        {
            await _postAppService.DeletePostAsync(id);
            return ResponseResult.CreateVoidResult();
        }

        [HttpGet]
        public async Task<ResponseResult<PageResult<PostDto>>> GetList(PostFilterDto dto)
        {
            return ResponseResult.Create(await _postAppService.GetListAsync(dto));
        }

        [HttpGet]
        public async Task<ResponseResult<PostDto>> GetPost(int id)
        {
            return ResponseResult.Create(await _postAppService.GetPostAsync(id));
        }

        [HttpPost]
        public async Task<ResponseResult> UpdatePostc(UpdatePostDto dto)
        {
            await _postAppService.UpdatePostAsync(dto);
            return ResponseResult.CreateVoidResult();
        }
    }
}

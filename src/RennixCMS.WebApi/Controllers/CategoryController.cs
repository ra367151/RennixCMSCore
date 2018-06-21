using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RennixCMS.Application.Post;
using RennixCMS.Domain.Category.Dtos;
using RennixCMS.Domain.Post.Dtos;
using RennixCMS.Infrastructure.Data;
using RennixCMS.Infrastructure.WebApi;
using RennixCMS.Application.Category;

namespace RennixCMS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [WrapWebApiException]
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService _categoryService;
        public CategoryController(ICategoryAppService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<ResponseResult<CategoryDto>> Create(CreateCategoryDto dto)
        {
            return ResponseResult.Create(await _categoryService.CreateCategoryAsync(dto));
        }

        [HttpPost]
        public async Task<ResponseResult> Update(UpdateCategoryDto dto)
        {
            await _categoryService.UpdateCategoryAsync(dto);
            return ResponseResult.CreateVoidResult();
        }

        [HttpPost]
        public async Task<ResponseResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return ResponseResult.CreateVoidResult();
        }

        [HttpGet]
        public async Task<ResponseResult<CategoryDto>> Get(int id)
        {
            return ResponseResult.Create(await _categoryService.GetCategoryAsync(id));
        }

        [HttpGet]
        public async Task<ResponseResult<IEnumerable<CategoryDto>>> GetList(CategoryFilterDto dto = null)
        {
            dto = dto ?? new CategoryFilterDto();
            return ResponseResult.Create(await _categoryService.GetCategoryListAsync(dto));
        }
    }
}

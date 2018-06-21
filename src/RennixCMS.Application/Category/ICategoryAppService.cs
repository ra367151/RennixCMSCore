using System;
using System.Collections.Generic;
using System.Text;
using RennixCMS.Domain.Category.Dtos;
using System.Threading.Tasks;

namespace RennixCMS.Application.Category
{
    public interface ICategoryAppService
    {
        Task<CategoryDto> GetCategoryAsync(int id);
        Task<IEnumerable<CategoryDto>> GetCategoryListAsync(CategoryFilterDto dto);

        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto dto);

        Task UpdateCategoryAsync(UpdateCategoryDto dto);

        Task DeleteCategoryAsync(int id);
    }
}

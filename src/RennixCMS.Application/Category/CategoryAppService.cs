using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RennixCMS.Domain.Category.Dtos;
using RennixCMS.Infrastructure.ApplicationService;
using AutoMapper;
using RennixCMS.Infrastructure.Data.UnitOfWork;
using RennixCMS.Domain.Category.Models;
using System.Linq.Expressions;
using System.Linq;

namespace RennixCMS.Application.Category
{
    public class CategoryAppService : ApplicationService, ICategoryAppService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IMapper _mapper;

        public CategoryAppService(IServiceProvider serviceProvider,
           IUnitOfWorkFactory unitOfWorkFactory,
           IMapper mapper) : base(serviceProvider)
        {
            _mapper = mapper;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto dto)
        {
            dto.ValidateProperties();

            using (var scope = _unitOfWorkFactory.CreateScope())
            {
                var repository = scope.Repository<RennixCMS.Domain.Category.Models.Category>();

                if (await repository.FirstOrDefaultAsync(x => x.ParentId == dto.ParentId && x.Name == dto.Name) != null)
                    throw new InvalidOperationException($"名称为{dto.Name}的栏目已经存在");

                var entity = await MapToEntityAsync<RennixCMS.Domain.Category.Models.Category>(dto);

                await repository.InsertAsync(entity);

                await scope.SaveChangesAsync();

                return await MapToDtoAsync<CategoryDto>(entity);
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            using (var scope = _unitOfWorkFactory.CreateScope())
            {
                var repository = scope.Repository<RennixCMS.Domain.Category.Models.Category>();

                var entity = await repository.FirstOrDefaultAsync(x => x.Id == id);
                if (entity != null)
                {
                    if (entity.Posts != null && entity.Posts.Any())
                        throw new InvalidOperationException($"{entity.Name}栏目下有内容，不允许删除");

                    await repository.DeleteAsync(id);

                    await scope.SaveChangesAsync();
                }
            }
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto dto)
        {
            dto.ValidateProperties();

            using (var scope = _unitOfWorkFactory.CreateScope())
            {
                var repository = scope.Repository<RennixCMS.Domain.Category.Models.Category>();

                if (await repository.FirstOrDefaultAsync(x => x.ParentId == dto.ParentId && x.Name == dto.Name) != null)
                    throw new InvalidOperationException($"名称为{dto.Name}的栏目已经存在");

                var entity = await MapToEntityAsync<RennixCMS.Domain.Category.Models.Category>(dto);

                await repository.UpdateAsync(entity);

                await scope.SaveChangesAsync();
            }
        }

        public async Task<CategoryDto> GetCategoryAsync(int id)
        {
            using (var scope = _unitOfWorkFactory.CreateScope())
            {
                var entity = await scope.Repository<RennixCMS.Domain.Category.Models.Category>().FirstOrDefaultAsync(x => x.Id == id);

                return await MapToDtoAsync<CategoryDto>(entity);
            }
        }
        public async Task<IEnumerable<CategoryDto>> GetCategoryListAsync(CategoryFilterDto dto)
        {
            using (var scope = _unitOfWorkFactory.CreateScope())
            {
                var list =  scope.Repository<RennixCMS.Domain.Category.Models.Category>().GetAll();

                var result = list.ToList()
                    .Select(x => MapToDtoAsync<CategoryDto>(x).ConfigureAwait(false).GetAwaiter().GetResult());

                return await Task.FromResult(result);
            }
        }
    }
}

using RennixCMS.Infrastructure.ApplicationService;
using System;
using System.Collections.Generic;
using System.Text;
using RennixCMS.Infrastructure.Data.UnitOfWork;
using RennixCMS.Domain.Post.Dtos;
using RennixCMS.Infrastructure.Data;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RennixCMS.Infrastructure.Extionsions;

namespace RennixCMS.Application.Post
{
	public class PostAppService : ApplicationService, IPostAppService
	{
		private readonly IUnitOfWorkFactory _unitOfWorkFactory;
		private readonly IMapper _mapper;
		public PostAppService(IServiceProvider serviceProvider,
			IUnitOfWorkFactory unitOfWorkFactory,
			IMapper mapper) : base(serviceProvider)
		{
			_unitOfWorkFactory = unitOfWorkFactory;
			_mapper = mapper;
		}

		public async Task ChangeVisiableStateAsync(int id, bool isVisiable)
		{
			using (var scope = _unitOfWorkFactory.CreateScope())
			{
				var post = await scope.Repository<Domain.Post.Models.Post>().GetAsync(id);
				if (post != null)
				{
					post.IsVisiable = isVisiable;

					await scope.SaveChangesAsync();
				}
			}
		}

		public async Task<int> CountAsync()
		{
			using (var scope = _unitOfWorkFactory.CreateScope())
			{
				return await scope.Repository<Domain.Post.Models.Post>().CountAsync();
			}
		}

		public async Task<PostDto> CreatePostAsync(CreatePostDto dto)
		{
			using (var scope = _unitOfWorkFactory.CreateScope())
			{
				dto.ValidateProperties();

				var entity = await MapToEntityAsync<Domain.Post.Models.Post>(dto);

				scope.Repository<Domain.Post.Models.Post>().Insert(entity);

				await scope.SaveChangesAsync();
				
				return await MapToDtoAsync<PostDto>(entity);
			}
		}

		public async Task DeletePostAsync(int id)
		{
			using (var scope = _unitOfWorkFactory.CreateScope())
			{
				await scope.Repository<Domain.Post.Models.Post>().DeleteAsync(x => x.Id == id);
				await scope.SaveChangesAsync();
			}
		}

		public async Task<PageResult<PostDto>> GetListAsync(PostFilterDto dto)
		{
			using (var scope = _unitOfWorkFactory.CreateScope())
			{
				var query = scope.Repository<Domain.Post.Models.Post>()
					.GetAll();

				query = query
					.WhereIf(dto.Author.IsNotNullOrEmpty(), x => x.Author == dto.Author)
					.WhereIf(dto.CategoryId.HasValue, x => x.CategoryId == dto.CategoryId)
					.WhereIf(dto.Content.IsNotNullOrEmpty(), x => x.Content.Contains(dto.Content))
					.WhereIf(dto.IsVisiable.HasValue, x => x.IsVisiable == dto.IsVisiable)
					.WhereIf(dto.Title.IsNotNullOrEmpty(), x => x.Title.Contains(dto.Title))
					.WhereIf(dto.BeginCreateTime.HasValue, x => x.CreateTime >= dto.BeginCreateTime)
					.WhereIf(dto.EndCreateTime.HasValue, x => x.CreateTime < dto.EndCreateTime);


				var count = query.Count();

				var skipTake = PageUtils.GetSkipTake(dto);
				query = query.OrderByDescending(x => x.CreateTime).Skip(skipTake.Skip).Take(skipTake.Take);

				return await Task.FromResult(new PageResult<PostDto>
				{
					PageIndex = dto.PageIndex,
					PageSize = dto.PageSize,
					Data = query.AsEnumerable().Select(x => MapToDtoAsync<PostDto>(x).ConfigureAwait(false).GetAwaiter().GetResult()).ToList(),
					TotalCount = count
				});
			}
		}

		public async Task<PostDto> GetPostAsync(int id)
		{
			using (var scope = _unitOfWorkFactory.CreateScope())
			{
				var post = scope.Repository<Domain.Post.Models.Post>().Get(id);

				return await MapToDtoAsync<PostDto>(post);
			}
		}

		public async Task UpdatePostAsync(UpdatePostDto dto)
		{
			using (var scope = _unitOfWorkFactory.CreateScope())
			{
				dto.ValidateProperties();

				var entity = await MapToEntityAsync<Domain.Post.Models.Post>(dto);

				await scope.Repository<Domain.Post.Models.Post>().UpdateAsync(entity);

			    await scope.SaveChangesAsync();
			}
		}
	}
}

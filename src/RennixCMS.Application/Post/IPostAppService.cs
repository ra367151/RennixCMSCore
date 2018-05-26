using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RennixCMS.Domain.Post.Dtos;
using RennixCMS.Infrastructure.Data;

namespace RennixCMS.Application.Post
{
	public interface IPostAppService
	{
		Task<PostDto> CreatePostAsync(CreatePostDto dto);

		Task UpdatePostAsync(UpdatePostDto dto);

		Task<PostDto> GetPostAsync(int id);

		Task DeletePostAsync(int id);

		Task ChangeVisiableStateAsync(int id, bool isVisiable);

		Task<PageResult<PostDto>> GetListAsync(PostFilterDto dto);

		Task<int> CountAsync();
	}
}

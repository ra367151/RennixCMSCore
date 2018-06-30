using AutoMapper;
using System;
using RennixCMS.Domain.Post.Dtos;
using RennixCMS.Domain.Post.Models;
using RennixCMS.Domain.Category.Dtos;
using RennixCMS.Domain.Setting.Dtos;

namespace RennixCMS.Application
{
	public class ApplicationServiceMapperConfiguration : Profile
	{
		public ApplicationServiceMapperConfiguration()
		{
			CreateMap<PostDto, Domain.Post.Models.Post>().ReverseMap();
			CreateMap<UpdatePostDto, Domain.Post.Models.Post>().ReverseMap();
			CreateMap<CreatePostDto, Domain.Post.Models.Post>().ReverseMap();
			CreateMap<CategoryDto, Domain.Category.Models.Category>().ReverseMap();
            CreateMap<CreateCategoryDto, Domain.Category.Models.Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Domain.Category.Models.Category>().ReverseMap();

            CreateMap<UpdateSettingDto, Domain.Setting.Models.Setting>().ReverseMap();
            CreateMap<SettingDto, Domain.Setting.Models.Setting>().ReverseMap();

            CreateMap<Domain.Comment.Dtos.CommentDto, Domain.Comment.Models.Comment>().ReverseMap();
		}
	}
}

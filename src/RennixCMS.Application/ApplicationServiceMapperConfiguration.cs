using AutoMapper;
using System;
using RennixCMS.Domain.Post.Dtos;
using RennixCMS.Domain.Post.Models;

namespace RennixCMS.Application
{
	public class ApplicationServiceMapperConfiguration : Profile
	{
		public ApplicationServiceMapperConfiguration()
		{
			CreateMap<PostDto, Domain.Post.Models.Post>().ReverseMap();
			CreateMap<UpdatePostDto, Domain.Post.Models.Post>().ReverseMap();
			CreateMap<CreatePostDto, Domain.Post.Models.Post>().ReverseMap();
		}
	}
}

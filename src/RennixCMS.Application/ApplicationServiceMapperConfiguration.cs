using AutoMapper;
using System;

namespace RennixCMS.Application
{
    public class ApplicationServiceMapperConfiguration : Profile
    {
        public ApplicationServiceMapperConfiguration()
        {
            CreateMap<MapDto, Map>().ReverseMap();
        }
    }
}

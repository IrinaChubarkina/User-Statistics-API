using AutoMapper;
using Domain.Core.Dtos;
using Domain.Core.Entities;
using WebApplication.Models;

namespace WebApplication.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserGroup, HistogramColumn>();
            
            CreateMap<UserDto, User>()
                .ReverseMap();
        }
    }
}
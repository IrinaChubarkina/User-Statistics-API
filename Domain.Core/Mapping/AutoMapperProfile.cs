using AutoMapper;
using Domain.Core.Dtos;
using Domain.Core.Entities;
using Shared.Extensions;

namespace Domain.Core.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            const string format = "dd.MM.yyyy";
            
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.RegistrationDate,
                    opt => opt.MapFrom(src => src.RegistrationDate.ToDateTime()))
                .ForMember(dest => dest.LastActivityDate,
                    opt => opt.MapFrom(src => src.LastActivityDate.ToDateTime()))
                .ReverseMap()
                .ForMember(dest => dest.RegistrationDate,
                    opt => opt.MapFrom(src => src.RegistrationDate.ToString(format)))
                .ForMember(dest => dest.LastActivityDate,
                    opt => opt.MapFrom(src => src.LastActivityDate.ToString(format)));
        }
    }
}
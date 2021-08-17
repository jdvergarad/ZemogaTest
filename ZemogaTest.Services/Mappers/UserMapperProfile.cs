using AutoMapper;
using ZemogaTest.Domain.Models;
using ZemogaTest.Services.Dtos;

namespace ZemogaTest.Services.Mappers
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<AddNewUserRequest, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(y => y.Password))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(y => y.Role))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(y => y.Username));

            CreateMap<User, AddNewUserResponse>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(y => y.Username));
        }
    }
}

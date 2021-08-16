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
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(y => y.UserName));

            CreateMap<User, AddNewUserResponse>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(y => y.UserName));
        }
    }
}

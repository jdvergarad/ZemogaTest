using AutoMapper;
using ZemogaTest.Domain.Models;
using ZemogaTest.Services.Dtos;

namespace ZemogaTest.Services.Mappers
{
    public class PostMapperProfile : Profile
    {
        public PostMapperProfile()
        {
            CreateMap<CreatePostRequest, Post>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(y => y.Content))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(y => y.Title));

            CreateMap<Post, CreatePostResponse>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(y => y.Content))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(y => y.CreatedDate))
                .ForMember(dest => dest.StatusMessage, opt => opt.MapFrom(y => y.StatusMessage))
                .ForMember(dest => dest.AuthorUserName, opt => opt.MapFrom(y => y.Author.UserName))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(y => y.Title));

            CreateMap<Post, PostDto>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(y => y.Content))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(y => y.Title))
                .ForMember(dest => dest.AuthorUsername, opt => opt.MapFrom(y => y.AuthorUserName))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(y => y.CreatedDate));
        }
    }
}

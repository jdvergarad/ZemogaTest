using System;
using System.Threading.Tasks;
using ZemogaTest.Services.Dtos;

namespace ZemogaTest.Services.Services
{
    public interface IPostService
    {
        Task<ApiResponse> GetAllPosts();
        Task<ApiResponse> GetPost(Guid postId);
        Task<ApiResponse> CreatePost(CreatePostRequest createPostRequest);
    }
}

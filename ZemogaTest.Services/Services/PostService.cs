using System;
using System.Threading.Tasks;
using ZemogaTest.Domain.Models;
using ZemogaTest.Repository.Repository;
using ZemogaTest.Services.Dtos;

namespace ZemogaTest.Services.Services
{
    public class PostService : IPostService
    {
        private IRepository<Post> _repository;
        public async Task<ApiResponse> CreatePost(CreatePostRequest createPostRequest)
        {
            ApiResponse response = new ApiResponse();
            await _repository.Create(new Post());
            return response;
        }

        public async Task<ApiResponse> GetAllPosts()
        {
            ApiResponse response = new ApiResponse();
            var result = await _repository.GetAll();
            return response;
        }

        public async Task<ApiResponse> GetPost(Guid postId)
        {
            ApiResponse response = new ApiResponse();
            var result = await _repository.Get(postId);
            return response;
        }
    }
}

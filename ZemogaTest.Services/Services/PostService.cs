using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZemogaTest.Services.Dtos;

namespace ZemogaTest.Services.Services
{
    public class PostService : IPostService
    {
        public Task<ApiResponse> CreatePost(CreatePostRequest createPostRequest)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetPost(Guid postId)
        {
            throw new NotImplementedException();
        }
    }
}

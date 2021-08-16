using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZemogaTest.Domain.Models;
using ZemogaTest.Repository.Repository;
using ZemogaTest.Services.Dtos;

namespace ZemogaTest.Services.Services
{
    public class PostService : IPostService
    {
        private IRepository<Post> _repositoryPost;
        private IRepository<User> _repositoryUser;
        private IMapper _mapper;

        public PostService(IRepository<Post> repositoryPost, IRepository<User> repositoryUser, IMapper mapper)
        {
            _repositoryPost = repositoryPost;
            _repositoryUser = repositoryUser;
            _mapper = mapper;
        }

        public async Task<ApiResponse> CreatePost(CreatePostRequest createPostRequest)
        {
            ApiResponse response = new ApiResponse();

            var userInDb = _repositoryUser.GetAll().Result.FirstOrDefault(user => user.UserName == createPostRequest.AuthorUsername);

            if (userInDb == null)
            {
                return new ErrorResponse { Mensaje = $"User: '{createPostRequest.AuthorUsername}' does not exist." };
            }

            var domainPost = _mapper.Map<Post>(createPostRequest);
            domainPost.Id = Guid.NewGuid();
            domainPost.Author = userInDb;
            domainPost.AuthorUserName = userInDb.UserName;
            domainPost.CreatedDate = DateTime.Now;
            domainPost.ModifiedDate = DateTime.Now;
            domainPost.Status = PostStatus.InProgress;
            domainPost.StatusMessage = PostStatus.InProgress.ToString();

            await _repositoryPost.Create(domainPost);

            return _mapper.Map<CreatePostResponse>(domainPost);
        }

        public async Task<ApiResponse> GetAllPosts()
        {
            GetAllPostsResponse response = new GetAllPostsResponse { Posts = new List<PostDto>()};
            var result = await _repositoryPost.GetAll();

            response.Posts = _mapper.Map<List<PostDto>>(result);

            return response;
        }

        public async Task<ApiResponse> GetPost(Guid postId)
        {
            ApiResponse response = new ApiResponse();
            var result = await _repositoryPost.Get(postId);
            return response;
        }
    }
}

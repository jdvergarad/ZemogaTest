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
        private IRepository<Comment> _repositoryComment;
        private IMapper _mapper;

        public PostService(IRepository<Post> repositoryPost, IRepository<User> repositoryUser,
                           IRepository<Comment> repositoryComment, IMapper mapper)
        {
            _repositoryPost = repositoryPost;
            _repositoryUser = repositoryUser;
            _repositoryComment = repositoryComment;
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

        public async Task<ApiResponse> GetAllPost(PostStatus postStatus)
        {
            GetAllPostsResponse response = new GetAllPostsResponse { Posts = new List<PostDto>()};
            var result = await _repositoryPost.GetAll();

            response.Posts = _mapper.Map<List<PostDto>>(result.Where(p => p.Status == postStatus));

            foreach (var post in response.Posts)
            {
                var commentsInDb = _repositoryComment.GetAll().Result.Where(c => c.PostId == post.PostId);
                post.Comments.AddRange(_mapper.Map<List<CommentDto>>(commentsInDb));
            }

            return response;
        }

        public async Task<ApiResponse> GetPost(Guid postId)
        {
            ApiResponse response = new ApiResponse();
            var result = await _repositoryPost.Get(postId);
            return response;
        }

        public async Task<ApiResponse> AddComment(AddCommentRequest addCommentRequest)
        {
            var postInDb = _repositoryPost.Get(addCommentRequest.PostId).Result;

            if (postInDb == null)
            {
                return new ErrorResponse { Mensaje = $"Post does not exist." };
            }

            if (postInDb.Status != PostStatus.Published)
            {
                return new ErrorResponse { Mensaje = $"Post is not publised." };
            }

            var userInDb = _repositoryUser.GetAll().Result.FirstOrDefault(user => user.UserName == addCommentRequest.AuthorUserName);

            if (userInDb == null)
            {
                return new ErrorResponse { Mensaje = $"User: '{addCommentRequest.AuthorUserName}' does not exist." };
            }

            var domainComment = _mapper.Map<Comment>(addCommentRequest);
            domainComment.Id = Guid.NewGuid();
            domainComment.Author = userInDb;
            domainComment.AuthorUserName = userInDb.UserName;
            domainComment.CreatedDate = DateTime.Now;
            domainComment.PostId = postInDb.Id;

            await _repositoryComment.Create(domainComment);

            var commentsForPost = _repositoryComment.GetAll().Result.Where(c => c.PostId == postInDb.Id);
            
            postInDb.Comments = new List<Comment>();
            postInDb.Comments.AddRange(commentsForPost);

            await _repositoryPost.Edit(postInDb);

            return _mapper.Map<CreatePostResponse>(postInDb);
        }

        public async Task<ApiResponse> SendForApproval(SendPostForApprovalRequest sendForApprovalRequest)
        {
            var postInDb = _repositoryPost.Get(sendForApprovalRequest.PostId).Result;

            if (postInDb == null)
            {
                return new ErrorResponse { Mensaje = $"Post does not exist."};
            }

            if (postInDb.Status == PostStatus.Published)
            {
                return new ErrorResponse { Mensaje = $"Post is already publised." };
            }

            postInDb.Status = PostStatus.PendingApproval;
            postInDb.StatusMessage = PostStatus.PendingApproval.ToString();
            postInDb.ModifiedDate = DateTime.Now;

            await _repositoryPost.Edit(postInDb);

            return _mapper.Map<CreatePostResponse>(postInDb);
        }

        public async Task<ApiResponse> GetAllPostByWriter(string writerUserName)
        {
            GetAllPostsResponse response = new GetAllPostsResponse();

            var userInDb = _repositoryUser.GetAll().Result.FirstOrDefault(user => user.UserName == writerUserName);

            if (userInDb == null)
            {
                return new ErrorResponse { Mensaje = $"User: '{writerUserName}' does not exist." };
            }

            var result = _repositoryPost.GetAll().Result.Where(p => p.AuthorUserName == writerUserName).ToList();

            response.Posts = _mapper.Map<List<PostDto>>(result);

            return response;
        }

        public Task<ApiResponse> GetAllPublisedPosts()
        {
            return GetAllPost(PostStatus.Published);
        }

        public Task<ApiResponse> GetAllPendingForApprovalPost()
        {
            return GetAllPost(PostStatus.PendingApproval);
        }

        public async Task<ApiResponse> EditPost(EditPostequest editPostequest)
        {
            var postInDb = _repositoryPost.Get(editPostequest.PostId).Result;

            if (postInDb == null)
            {
                return new ErrorResponse { Mensaje = $"Post does not exist." };
            }

            if (postInDb.Status == PostStatus.Published)
            {
                return new ErrorResponse { Mensaje = $"Post is already publised." };
            }

            postInDb.Status = PostStatus.InProgress;
            postInDb.StatusMessage = PostStatus.InProgress.ToString();
            postInDb.Title = editPostequest.NewTitle;
            postInDb.Content = editPostequest.NewContent;
            postInDb.ModifiedDate = DateTime.Now;

            await _repositoryPost.Edit(postInDb);

            return _mapper.Map<CreatePostResponse>(postInDb);
        }

        public async Task<ApiResponse> ApproveOrReject(ApproveOrRejectPost approveOrRejectPost)
        {
            var postInDb = _repositoryPost.Get(approveOrRejectPost.PostId).Result;

            if (postInDb == null)
            {
                return new ErrorResponse { Mensaje = $"Post does not exist." };
            }

            if (postInDb.Status != PostStatus.PendingApproval)
            {
                return new ErrorResponse { Mensaje = $"Post is not ready for approval" };
            }

            if(approveOrRejectPost.Decision == 0)
            {
                postInDb.PublishedDate = DateTime.Now;
                postInDb.Status = PostStatus.Published;
            }
            else
            {
                postInDb.Status = PostStatus.Rejected;
            }

            postInDb.StatusMessage = approveOrRejectPost.Message;
            postInDb.ModifiedDate = DateTime.Now;

            await _repositoryPost.Edit(postInDb);

            return _mapper.Map<CreatePostResponse>(postInDb);
        }
    }
}

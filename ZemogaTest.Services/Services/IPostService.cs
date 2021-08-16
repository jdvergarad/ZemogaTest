using System;
using System.Threading.Tasks;
using ZemogaTest.Domain.Models;
using ZemogaTest.Services.Dtos;

namespace ZemogaTest.Services.Services
{
    public interface IPostService
    {
        Task<ApiResponse> GetAllPost(PostStatus postStatus);
        Task<ApiResponse> GetAllPostByWriter(string writerUserName);
        Task<ApiResponse> GetAllPublisedPosts();
        Task<ApiResponse> GetAllPendingForApprovalPost();
        Task<ApiResponse> GetPost(Guid postId);
        Task<ApiResponse> CreatePost(CreatePostRequest createPostRequest);
        Task<ApiResponse> EditPost(EditPostequest editPostequest);
        Task<ApiResponse> AddComment(AddCommentRequest createPostRequest);
        Task<ApiResponse> SendForApproval(SendPostForApprovalRequest sendForApprovalRequest);
        Task<ApiResponse> ApproveOrReject(ApproveOrRejectPost approveOrRejectPost);
    }
}

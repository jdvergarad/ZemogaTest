using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZemogaTest.Services.Dtos;

namespace ZemogaTest.Services.Services
{
    public interface ICommentService
    {
        Task<ApiResponse> AddComment(AddCommentRequest createPostRequest);
    }
}

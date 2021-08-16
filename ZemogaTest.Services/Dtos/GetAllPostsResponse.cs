using System.Collections.Generic;

namespace ZemogaTest.Services.Dtos
{
    public class GetAllPostsResponse : ApiResponse
    {
        public List<PostDto> Posts { get; set; }
    }
}

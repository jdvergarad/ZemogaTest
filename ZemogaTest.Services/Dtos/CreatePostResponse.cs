using System;

namespace ZemogaTest.Services.Dtos
{
    public class CreatePostResponse : ApiResponse
    {
        public string AuthorUserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string StatusMessage { get; set; }
    }
}

using System;

namespace ZemogaTest.Services.Dtos
{
    public class AddCommentRequest
    {
        public Guid PostId { get; set; }
        public string AuthorUsername { get; set; }
        public string Content { get; set; }
    }
}

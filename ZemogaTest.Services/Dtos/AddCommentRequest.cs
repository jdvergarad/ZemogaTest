using System;

namespace ZemogaTest.Services.Dtos
{
    public class AddCommentRequest
    {
        public Guid PostId { get; set; }
        public Guid AuthorId { get; set; }
        public string Content { get; set; }
    }
}

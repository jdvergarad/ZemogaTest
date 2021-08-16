using System;

namespace ZemogaTest.Services.Dtos
{
    public class CommentDto
    {
        public string AuthorUsername { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

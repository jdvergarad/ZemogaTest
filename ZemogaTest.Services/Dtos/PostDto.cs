using System;
using System.Collections.Generic;

namespace ZemogaTest.Services.Dtos
{
    public class PostDto
    {
        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string Status { get; set; }
        public string StatusMessage { get; set; }
        public string AuthorUsername { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}

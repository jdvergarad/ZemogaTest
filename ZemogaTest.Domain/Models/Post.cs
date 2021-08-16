using System;
using System.Collections.Generic;

namespace ZemogaTest.Domain.Models
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime? PublishedDate { get; set; }
        public PostStatus Status { get; set; }
        public User Author { get; set; }
        public List<Comment> Comments { get; set; }
    }
}

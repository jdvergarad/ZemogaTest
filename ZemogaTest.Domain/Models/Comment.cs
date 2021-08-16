using System;

namespace ZemogaTest.Domain.Models
{
    public class Comment : BaseEntity
    {
        public User Author { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

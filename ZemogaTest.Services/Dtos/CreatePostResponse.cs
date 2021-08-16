﻿using System;

namespace ZemogaTest.Services.Dtos
{
    public class CreatePostResponse : ApiResponse
    {
        public Guid PostId { get; set; }
        public string AuthorUserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string StatusMessage { get; set; }
    }
}

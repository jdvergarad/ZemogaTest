using System;

namespace ZemogaTest.Services.Dtos
{
    public class EditPostequest
    {
        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}

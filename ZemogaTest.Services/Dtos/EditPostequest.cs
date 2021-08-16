using System;

namespace ZemogaTest.Services.Dtos
{
    public class EditPostequest
    {
        public Guid PostId { get; set; }
        public string NewTitle { get; set; }
        public string NewContent { get; set; }
    }
}

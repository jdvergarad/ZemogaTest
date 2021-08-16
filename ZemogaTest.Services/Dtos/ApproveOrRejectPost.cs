using System;

namespace ZemogaTest.Services.Dtos
{
    public class ApproveOrRejectPost
    {
        public Guid PostId { get; set; }
        public string Message { get; set; }
        public int Decision { get; set; }
    }
}

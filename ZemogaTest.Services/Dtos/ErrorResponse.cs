using System.Text.Json.Serialization;

namespace ZemogaTest.Services.Dtos
{
    public class ErrorResponse : ApiResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}

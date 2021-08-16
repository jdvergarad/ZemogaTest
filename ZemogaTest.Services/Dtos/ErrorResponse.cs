using System.Text.Json.Serialization;

namespace ZemogaTest.Services.Dtos
{
    public class ErrorResponse : ApiResponse
    {
        [JsonPropertyName("mensaje")]
        public string Mensaje { get; set; }
    }
}

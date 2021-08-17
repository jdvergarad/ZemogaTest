namespace ZemogaTest.Services.Dtos
{
    public class LoginResponse : ApiResponse
    {
        public string Token { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
    }
}

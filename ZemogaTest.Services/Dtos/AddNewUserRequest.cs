namespace ZemogaTest.Services.Dtos
{
    public class AddNewUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}

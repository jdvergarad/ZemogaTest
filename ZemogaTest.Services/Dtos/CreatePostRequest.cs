namespace ZemogaTest.Services.Dtos
{
    public class CreatePostRequest
    {
        public string AuthorUsername { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}

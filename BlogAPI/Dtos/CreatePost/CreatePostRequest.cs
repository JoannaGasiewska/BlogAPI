namespace BlogAPI.Dtos.CreatePost
{
    public class CreatePostRequest
    {
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
    }
}
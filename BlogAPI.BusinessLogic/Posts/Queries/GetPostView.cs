using BlogAPI.BusinessLogic.Posts.Entities;

namespace BlogAPI.BusinessLogic.Posts.Queries
{
    public class GetPostView
    {
        public int AuthorId { get; set; }
        public GetPostViewAuthor? Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
    }

    public class GetPostViewAuthor
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}

using BlogAPI.BusinessLogic.Posts.Entities;
using BlogAPI.BusinessLogic.Posts.Queries;

namespace BlogAPI.BusinessLogic.Posts.Repositories
{
    public interface IPostRepository
    {
        Task Create(Post? post);
        Task<GetPostView?> GetPost(int id, bool includeAuthor);
    }
}

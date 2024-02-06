using BlogAPI.BusinessLogic.Posts.Entities;

namespace BlogAPI.BusinessLogic.Posts.Repositories
{
    public interface IAuthorRepository
    {
        Task<Author> GetAuthorAsync(int id);
    }
}

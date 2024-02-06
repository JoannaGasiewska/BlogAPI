using BlogAPI.BusinessLogic.Posts.Entities;
using BlogAPI.BusinessLogic.Posts.Queries;
using BlogAPI.BusinessLogic.Utils;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.BusinessLogic.Posts.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDataContext _unitOfWork;

        public PostRepository(BlogDataContext dataContext)
        {
            _unitOfWork = dataContext;
        }

        public async Task Create(Post? post)
        {
            _unitOfWork.Post.Add(post);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<GetPostView?> GetPost(int id, bool includeAuthor)
        {
            IQueryable<Post?> postQuery = _unitOfWork.Post.Where(x => x.Id == id);
            if (includeAuthor)
            {
                postQuery = postQuery.Include(x => x.Author);
            }

            Post? post = await postQuery.FirstOrDefaultAsync();
            if (post == null)
            {
                throw new NotFoundException();
            }

            return new GetPostView
            {
                AuthorId = post.AuthorId,
                Author = includeAuthor ? new GetPostViewAuthor
                {
                    Name = post.Author.Name,
                    Surname = post.Author.Surname,
                }: null,
                Content = post.Content,
                Description = post.Description, 
                Title = post.Title,
            };
        }
    }
}

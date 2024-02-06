using BlogAPI.BusinessLogic.Posts.Commands;
using BlogAPI.BusinessLogic.Posts.Repositories;

namespace BlogAPI.BusinessLogic.Posts.Queries
{
    public class GetPostQuery : IQuery<GetPostView>
    {
        public int Id { get; set; }
        public bool IncludeAuthor { get; set; }

        public class GetPostQueryHandler : IQueryHandler<GetPostQuery, GetPostView>
        {
            private readonly IAuthorRepository _authorRepository;
            private readonly IPostRepository _postRepository;

            public GetPostQueryHandler(IAuthorRepository authorRepository, 
                IPostRepository postRepository)
            {
                _authorRepository = authorRepository;
                _postRepository = postRepository;
            }

            public Task<GetPostView?> HandleAsync(GetPostQuery query)
            {
                return _postRepository.GetPost(query.Id, query.IncludeAuthor);
            }
        }
    }
}

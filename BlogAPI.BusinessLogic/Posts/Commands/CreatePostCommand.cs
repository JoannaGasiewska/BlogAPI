using BlogAPI.BusinessLogic.Posts.Entities;
using BlogAPI.BusinessLogic.Posts.Repositories;
using BlogAPI.BusinessLogic.Utils;

namespace BlogAPI.BusinessLogic.Posts.Commands
{
    public class CreatePostCommand : ICommand
    {
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public class CreatePostCommandHandler : ICommandHandler<CreatePostCommand, int>
        {
            private readonly IAuthorRepository _authorRepository;
            private readonly IPostRepository _postRepository;

            public CreatePostCommandHandler(IAuthorRepository authorRepository,
                IPostRepository postRepository)
            {
                _authorRepository = authorRepository;
                _postRepository = postRepository;
            }

            public async Task<int> HandleAsync(CreatePostCommand command)
            {
                Author author = await _authorRepository.GetAuthorAsync(command.AuthorId);
                if (author == null)
                {
                    throw new BlogValidationException(nameof(command.AuthorId), "not found");
                }

                var post = new Post(author, command.Title, command.Description, command.Content);
                await _postRepository.Create(post);
                return post.Id;
            }
        }
    }
}
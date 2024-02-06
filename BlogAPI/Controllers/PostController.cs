using BlogAPI.BusinessLogic.Posts.Commands;
using BlogAPI.BusinessLogic.Posts.Queries;
using BlogAPI.BusinessLogic.Posts.Repositories;
using BlogAPI.BusinessLogic.Utils;
using BlogAPI.Dtos.CreatePost;
using BlogAPI.Dtos.GetPost;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController: ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IPostRepository _postsRepository;

        public PostController(IAuthorRepository authorRepository,
            IPostRepository postRepository)
        {
            _authorRepository = authorRepository;
            _postsRepository = postRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostRequest request)
        {
            var command = new CreatePostCommand
            {
                AuthorId = request.AuthorId,
                Title = request.Title,
                Description = request.Description,
                Content = request.Content
            };

            try
            {
                var handler = new CreatePostCommand.CreatePostCommandHandler(_authorRepository, _postsRepository);
                int id = await handler.HandleAsync(command);

                return Ok(new CreatePostResponse
                {
                    Id = id
                });
            }
            catch (BlogValidationException e)
            {
                return BadRequest(new { FieldName = e.FieldName, Error= e.ErrorMessage });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id, [FromQuery] bool includeAuthor)
        {
            var query = new GetPostQuery
            {
                Id = id,
                IncludeAuthor = includeAuthor,
            };

            try
            {
                var handler = new GetPostQuery.GetPostQueryHandler(_authorRepository, _postsRepository);
                return Ok(await handler.HandleAsync(query));
            }
            catch (NotFoundException e)
            {
                return NotFound();
            }
        }
    }
}

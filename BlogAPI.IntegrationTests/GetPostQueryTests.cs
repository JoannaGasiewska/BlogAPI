using BlogAPI.BusinessLogic.Posts.Entities;
using BlogAPI.BusinessLogic.Posts.Queries;
using BlogAPI.BusinessLogic.Posts.Repositories;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogAPI.IntegrationTests
{
    [TestClass]
    public class GetPostQueryTests : TestsBase
    {
        [TestMethod]
        public async Task GetPostQuery_WhenIncludeAuthor_ShouldReturnWithAuthor()
        {

            // Arrange

            var query = new GetPostQuery
            {
                Id = 1,
                IncludeAuthor = true
            };

            var blogDataContext = GetMemoryContext();
            var authorRepository = new AuthorRepository(blogDataContext);
            var postRepository = new PostRepository(blogDataContext);
            await postRepository.Create(new Post( blogDataContext.Author.First(), "title", "description", "content"));

            var queryHandler = new GetPostQuery.GetPostQueryHandler(authorRepository, postRepository);

            GetPostView expectedPost = new GetPostView
            {
                Author = new GetPostViewAuthor
                {
                    Name = "Some",
                    Surname = "Author"
                },
                AuthorId = 1,
                Content = "content",
                Description = "description",
                Title = "title"
            };

            // Act

            GetPostView post = await queryHandler.HandleAsync(query);

            //Assert

            post.Should().BeEquivalentTo(expectedPost);
        }

        [TestMethod]
        public async Task GetPostQuery_WhenNotIncludeAuthor_ShouldReturnWithAuthor()
        {

            // Arrange

            var query = new GetPostQuery
            {
                Id = 1,
                IncludeAuthor = false
            };

            var blogDataContext = GetMemoryContext();
            var authorRepository = new AuthorRepository(blogDataContext);
            var postRepository = new PostRepository(blogDataContext);
            await postRepository.Create(new Post(blogDataContext.Author.First(), "title", "description", "content"));

            var queryHandler = new GetPostQuery.GetPostQueryHandler(authorRepository, postRepository);

            GetPostView expectedPost = new GetPostView
            {
                Author = null,
                AuthorId = 1,
                Content = "content",
                Description = "description",
                Title = "title"
            };

            // Act

            GetPostView post = await queryHandler.HandleAsync(query);

            //Assert

            post.Should().BeEquivalentTo(expectedPost);
        }
    }
}

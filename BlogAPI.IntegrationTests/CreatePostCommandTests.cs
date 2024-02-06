using BlogAPI.BusinessLogic.Posts.Commands;
using BlogAPI.BusinessLogic.Posts.Queries;
using BlogAPI.BusinessLogic.Posts.Repositories;
using BlogAPI.BusinessLogic.Utils;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogAPI.IntegrationTests
{
    [TestClass]
    public class CreatePostCommandTests : TestsBase
    {
        [TestMethod]
        public async Task CreatePostCommand_ShouldReturnId_WhenExistingAuthor()
        {
            // Arrange

            var command = new CreatePostCommand
            {
                AuthorId = 1,
                Title = "some title",
                Description = "some description",
                Content = "some content"
            };

            var blogDataContext = GetMemoryContext();
            var authorRepository = new AuthorRepository(blogDataContext);
            var postRepository = new PostRepository(blogDataContext);

            var commandHandler = new CreatePostCommand.CreatePostCommandHandler(authorRepository, postRepository);

            var expectedPost = new GetPostView
            {
                Author = new GetPostViewAuthor
                {
                    Name = "Some",
                    Surname = "Author"
                },
                AuthorId = 1,
                Content = "some content",
                Description = "some description",
                Title = "some title"
            };

            // Act

            int id = await commandHandler.HandleAsync(command);

            // Assert
            
            var createdPost = await postRepository.GetPost(1, true);
            createdPost.Should().BeEquivalentTo(expectedPost);
            id.Should().Be(1);
        }

        [TestMethod]
        public async Task CreatePostCommand_ShouldThrowValidationException_WhenNonExistingAuthor()
        {
            // Arrange

            var command = new CreatePostCommand
            {
                AuthorId = 2,
                Title = "some title",
                Description = "some description",
                Content = " some content"
            };

            var blogDataContext = GetMemoryContext();
            var authorRepository = new AuthorRepository(blogDataContext);
            var postRepository = new PostRepository(blogDataContext);

            var commandHandler = new CreatePostCommand.CreatePostCommandHandler(authorRepository, postRepository);

            // Act

            Func<Task> a = async () => await commandHandler.HandleAsync(command);

            // Assert

            await a.Should().ThrowAsync<BlogValidationException>();
        }
    }
}

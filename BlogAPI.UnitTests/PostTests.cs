using BlogAPI.BusinessLogic.Posts.Entities;
using BlogAPI.BusinessLogic.Utils;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogAPI.UnitTests
{
    [TestClass]
    public class PostTests
    {
        [TestMethod]
        public void Post_WhenValuesOK_ShouldCreatePost()
        {
            // Arrange

            var author = new Author("", "");
            var post = new Post(author, "Test title", "Test description", "Test content");

            // Act & Assert

            post.Title.Should().BeEquivalentTo("Test title");
            post.Description.Should().BeEquivalentTo("Test description");
            post.Content.Should().BeEquivalentTo("Test content");
        }

        [TestMethod]
        public void Post_WhenTitleEmpty_ShouldThrowValidationException()
        {
            // Arrange

            var author = new Author("", "");
            Action a = () => new Post(author, "", "", "");

            // Act & Assert

            a.Should().Throw<BlogValidationException>();
        }

        [TestMethod]
        public void Post_WhenTitleNull_ShouldThrowValidationException()
        {
            // Arrange

            var author = new Author("", "");
            Action a = () => new Post(author, null, "", "");

            // Act & Assert

            a.Should().Throw<BlogValidationException>();
        }

        [TestMethod]
        public void Post_WhenTitleToolLong_ShouldThrowValidationException()
        {
            // Arrange

            var author = new Author("", "");
            Action a = () => new Post(author, new string('a', 2001), "", "");

            // Act & Assert

            a.Should().Throw<BlogValidationException>();
        }

        [TestMethod]
        public void Post_WhenDescriptionEmptyLong_ShouldThrowValidationException()
        {
            // Arrange

            var author = new Author("", "");
            Action a = () => new Post(author, new string('a', 2000), "", "");

            // Act & Assert

            a.Should().Throw<BlogValidationException>();
        }

        [TestMethod]
        public void Post_WhenDescriptionNull_ShouldThrowValidationException()
        {
            // Arrange

            var author = new Author("", "");
            Action a = () => new Post(author, new string('a', 2000), null, "");

            // Act & Assert

            a.Should().Throw<BlogValidationException>();
        }

        [TestMethod]
        public void Post_WhenDescriptionToolLong_ShouldThrowValidationException()
        {
            // Arrange

            var author = new Author("", "");
            Action a = () => new Post(author, new string('a', 2000), new string('b', 4001), "");

            // Act & Assert

            a.Should().Throw<BlogValidationException>();
        }
    }
}

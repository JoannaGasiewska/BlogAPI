using BlogAPI.BusinessLogic;
using BlogAPI.BusinessLogic.Posts.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.IntegrationTests
{
    public abstract class TestsBase
    {
        public BlogDataContext GetMemoryContext()
        {
            var cnn = new SqliteConnection("Filename=:memory:");
            cnn.Open();

            var options = new DbContextOptionsBuilder<BlogDataContext>()
                .UseSqlite(cnn)
                .Options;
            var context = new BlogDataContext(options);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (!context.Author.Any())
            {
                context.Author.Add(new Author("Some", "Author"));
                context.SaveChanges();
            }

            return context;
        }
    }
}

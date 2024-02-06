using BlogAPI.BusinessLogic.Posts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlogAPI.BusinessLogic
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Author> Author { get; set; } = null!;
        public DbSet<Post?> Post { get; set; } = null!;

        public BlogDataContext(DbContextOptions<BlogDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasMany<Post>().WithOne(x => x.Author).IsRequired();
            });

            modelBuilder.Entity<Post>(entity =>
            {
            });
        }
    }
}

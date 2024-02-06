using BlogAPI.BusinessLogic.Utils;

namespace BlogAPI.BusinessLogic.Posts.Entities
{
    public class Post : Entity
    {
        public int AuthorId { get; private set; }
        public Author Author { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Content { get; private set; }

        protected Post() { }

        public Post(Author author, string title, string description, string content)
        {
            ValidateTitle(title);
            ValidateDescription(description);
            
            if (author == null || author.Id == default)
            {
                throw new BlogValidationException(nameof(author), " does not exist");
            }

            this.AuthorId = author.Id;
            this.Author = author;
            this.Title = title;
            this.Description = description;
            this.Content = content;
        }

        private void ValidateTitle(string title)
        {
            ValidateNonEmpty(nameof(title),title);
            ValidateMaxLength(2000, nameof(title), title);
        }

        private void ValidateDescription(string description)
        {
            ValidateNonEmpty(nameof(description), description);
            ValidateMaxLength(4000, nameof(description), description);
        }
    }
}

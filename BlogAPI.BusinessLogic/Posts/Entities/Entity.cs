using BlogAPI.BusinessLogic.Utils;

namespace BlogAPI.BusinessLogic.Posts.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        protected void ValidateNonEmpty(string fieldName, string fieldValue)
        {
            if (string.IsNullOrEmpty(fieldValue))
            {
                throw new BlogValidationException(nameof(fieldName), "Must not be empty");
            }
        }

        protected void ValidateMaxLength(int maxLength, string fieldName, string fieldValue)
        {
            if (fieldValue.Length > maxLength)
            {
                throw new BlogValidationException(nameof(fieldName), $"may be of max {maxLength}");
            }
        }
    }
}

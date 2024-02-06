namespace BlogAPI.BusinessLogic.Utils
{
    public class BlogValidationException : Exception
    {
        public string FieldName { get; private set; }
        public string ErrorMessage { get; private set; }

        public BlogValidationException(string fieldName, string errorMessage) : base($"Field {fieldName} => {errorMessage}")
        {
            FieldName = fieldName;
            ErrorMessage = errorMessage;
        }
    }
}

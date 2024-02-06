namespace BlogAPI.BusinessLogic.Utils
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Not found")
        {

        }
    }
}

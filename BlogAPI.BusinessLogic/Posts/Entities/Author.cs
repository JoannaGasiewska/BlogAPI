namespace BlogAPI.BusinessLogic.Posts.Entities
{
    public class Author: Entity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }

        protected Author() { }

        public Author(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}

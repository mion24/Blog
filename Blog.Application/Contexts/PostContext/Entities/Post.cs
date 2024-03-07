namespace Blog.Application.Contexts.PostContext.Entities
{
    public class Post
    {
        public Post(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

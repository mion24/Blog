namespace Blog.Application.Contexts.AccountContext.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = null!;
        public string Password { get; private set; } = null!;
    }
}

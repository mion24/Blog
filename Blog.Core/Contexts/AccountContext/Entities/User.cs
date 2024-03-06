using Blog.Core.Contexts.AccountContext.ValueObjects;
using Blog.Core.Contexts.PostContext.Entities;
using Blog.Core.Contexts.SharedContext.Entities;

namespace Blog.Core.Contexts.AccountContext.Entities
{
    public class User : Entity
    {
        protected User() {}
        public User(string name, Email email, Password password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
        public string Name { get; private set; } = string.Empty;
        public Email Email { get; private set; } = null!;
        public Password Password { get; private set; } = null!;
    }
}

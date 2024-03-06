using SecureIdentity.Password;

namespace Blog.Core.Contexts.AccountContext.ValueObjects
{
    public class Password
    {
        protected Password()
        { }

        public Password(string plainPassword)
        {
            Hash = PasswordHasher.Hash(plainPassword);
        }

        public string Hash { get; } = string.Empty;
    }
}

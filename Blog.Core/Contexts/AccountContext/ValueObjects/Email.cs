using Blog.Core.Contexts.SharedContext.ValueObjects;
using System.Text.RegularExpressions;

namespace Blog.Core.Contexts.AccountContext.ValueObjects
{
    public partial class Email : ValueObject
    {
        private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        public Email(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new Exception("Email invalido");

            Address = address.Trim().ToLower();

            if (Address.Length < 5)
                throw new Exception("Email invalido");

            if (!EmailRegex().IsMatch(Address))
                throw new Exception("Email invalido");
        }

        public string Address { get; set; }

        public static implicit operator string(Email email)
           => email.ToString();

        public static implicit operator Email(string address)
            => new Email(address);

        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex();

    }
}

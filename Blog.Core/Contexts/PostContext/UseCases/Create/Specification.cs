using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Contexts.PostContext.UseCases.Create
{
    public static class Specification
    {
        public static Contract<Notification> Ensure(Request request)
          => new Contract<Notification>()
            .Requires()
            .IsNotNull(request.Title, "Title")
            .IsNotNull(request.Description, "Description")
            .IsLowerThan(request.Title, 50, "Title", "O titulo da publicação deve ter menos que 50 caracteres.")
            .IsGreaterThan(request.Title, 3, "Title", "O titulo da publicação deve ter ao menos 3 caracteres.")
            .IsLowerThan(request.Description, 300, "Description", "O corpo da publicação deve ter menos que 300 caracteres.")
            .IsGreaterThan(request.Description, 3, "Description", "O copo da publicação deve ter ao menos 3 caracteres.");
    }
}

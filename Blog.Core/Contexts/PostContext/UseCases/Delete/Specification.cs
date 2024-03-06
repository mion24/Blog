using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Contexts.PostContext.UseCases.Delete
{
    internal class Specification
    {
        public static Contract<Notification> Ensure(Request request)
          => new Contract<Notification>()
            .Requires()
            .IsNotNull(request.Id, "Id");
    }
}

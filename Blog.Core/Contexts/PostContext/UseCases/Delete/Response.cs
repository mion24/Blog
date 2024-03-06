using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Contexts.PostContext.UseCases.Delete
{
    public class Response : SharedContext.UseCases.Response
    {
        protected Response()
        {
        }

        public Response(string message, int status, IEnumerable<Notification>? notifications = null)
        {
            Message = message;
            Status = status;
            Notifications = notifications;
        }

        public Response(string message)
        {
            Message = message;
            Status = 200;
            Notifications = null;
        }
    }
}


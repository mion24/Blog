using Blog.Core.Contexts.PostContext.Entities;
using Blog.Core.Contexts.SharedContext.UseCases;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Contexts.PostContext.UseCases.GetAll
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

        public Response(ResponseData data)
        {
            Status = 200;
            Notifications = null;
            Data = data;
        }

        public ResponseData? Data { get; set; }
    }

    public record ResponseData(IEnumerable<Post> Posts);
}


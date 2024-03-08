using Flunt.Notifications;

namespace Blog.Core.Contexts.PostContext.UseCases.Delete
{
    public class Response : SharedContext.UseCases.Response
    {
        public Response()
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

        public Response(ResponseData? data, string? message = "")
        {
            Message = message ?? "";
            Status = 201;
            Notifications = null;
            Data = data;
        }
        public ResponseData? Data { get; set; }

    }

    public record ResponseData(string Id);
}


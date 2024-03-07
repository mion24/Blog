using Blog.Core.Contexts.PostContext.Entities;
using Blog.Core.Contexts.PostContext.UseCases.Put.Contracts;
using Blog.Core.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Blog.Core.Contexts.PostContext.UseCases.Put
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IRepository _repository;
        private readonly IHttpContextAccessor _httpContextAcessor;

        public Handler(IRepository repository, IHttpContextAccessor contextAccessor)
        {
            _repository = repository;
            _httpContextAcessor = contextAccessor;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            try
            {
                var res = Specification.Ensure(request);

                if (!res.IsValid)
                {
                    return new Response("Requisição invalida.", 400, res.Notifications);
                }
            }
            catch
            {
                return new Response("Requisição não processada", 500);
            }           

            var post = await _repository.GetPost(request.Id, cancellationToken);

            if (post is null)
            {
                return new Response("Postagem não encontrada", 404);
            }

            if (!post.OwnerID.Equals(new Guid(_httpContextAcessor.HttpContext.User.Id())))
            {
                return new Response("Usuario não é autor da postagem.", 400);
            }

            post.Update(request);

            await _repository.PutPost(post, cancellationToken);

            return new Response(post.Id.ToString());
        }
    }
}

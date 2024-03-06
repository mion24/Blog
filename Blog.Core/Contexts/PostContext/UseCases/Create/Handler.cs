using Blog.Core.Contexts.PostContext.Entities;
using Blog.Core.Contexts.PostContext.UseCases.Create.Contracts;
using Blog.Core.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Blog.Core.Contexts.PostContext.UseCases.Create
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IRepository _repository;
        private readonly IHttpContextAccessor _httpContextAcessor;
        public Handler(IRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAcessor = httpContextAccessor;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            try
            {
                var res = Specification.Ensure(request);

                if (!res.IsValid)
                {
                    return new Response("Requisição inválida", 400, res.Notifications);
                }
            }
            catch
            {
                return new Response("Requisição não processada", 500);
            }

            Post post;

            try
            {
                post = new(request.Title, request.Description, DateTime.UtcNow, false, new Guid(_httpContextAcessor.HttpContext.User.Id()));
            }
            catch
            {
                return new Response("Falha na criação do Post", 500);
            }

            try
            {
                await _repository.SaveAsync(post, cancellationToken);
            }
            catch
            {
                return new Response("Falha ao persistir dados", 500);
            }

            return new Response("Post criado com sucesso", new ResponseData(post.Id));
        }
    }
}

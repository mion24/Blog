using Blog.Core.Contexts.PostContext.UseCases.Delete.Contracts;
using Blog.Core.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Contexts.PostContext.UseCases.Delete
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
                    return new Response("Requisição invalida", 400, res.Notifications);
                }
            }
            catch
            {
                return new Response("Requisição não processada", 500);
            }

            try
            {
                var post = await _repository.GetPost(new Guid(request.Id), cancellationToken);

                if (post is null)
                {
                    return new Response("Postagem não encontrada", 404);
                }

                if (!post.OwnerID.Equals(new Guid(_httpContextAcessor.HttpContext.User.Id())))
                {
                    return new Response("Usuario não é autor da postagem.", 400);
                }

                await _repository.Delete(post);
                return new Response(new ResponseData(post.Id.ToString()), "Excluido com sucesso");
            }
            catch (FormatException)
            {
                return new Response("Falha ao formatar ID, deve ser um GUID.", 400);
            }
            catch 
            {
                return new Response("Falha ao recuperar postagem", 500);
            }
            
        }
    }
}

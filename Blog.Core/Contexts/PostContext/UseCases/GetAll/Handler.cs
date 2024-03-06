using Blog.Core.Contexts.PostContext.Entities;
using Blog.Core.Contexts.PostContext.UseCases.GetAll.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Contexts.PostContext.UseCases.GetAll
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IRepository _repository;

        public Handler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
			try
			{
                IEnumerable<Post> posts = await _repository.GetAllAsync(cancellationToken);

                if (!posts.Any())
                {
                    return new Response("Não foram encontrados dados", 204);
                }

                return new Response(new ResponseData(posts));
            }
			catch
			{
                return new Response("Requisição não processada", 500);
			}
        }
    }
}

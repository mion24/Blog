using Blog.Core.Contexts.AccountContext.Entities;
using Blog.Core.Contexts.AccountContext.UseCases.Create.Contracts;
using Blog.Core.Contexts.AccountContext.ValueObjects;
using MediatR;

namespace Blog.Core.Contexts.AccountContext.UseCases.Create
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
            
            Email email;
            Password password;
            User user;

            try
            {
                email = new(request.Email);
                password = new(request.Password);
                user = new(request.Name, email, password);
            }
            catch (Exception e)
            {
                return new Response(e.Message, 400);
            }
            
            try
            {
                var exists = await _repository.AnyAsync(request.Email, cancellationToken);

                if (exists)
                    return new Response("Este E-mail já está em uso", 400);
            }
            catch
            {
                return new Response("Falha ao verificar email cadastrado", 500);
            }

            
            try
            {
                await _repository.SaveAsync(user, cancellationToken);
            }
            catch
            {
                return new Response("Falha ao persistir dados", 500);
            }

            return new Response("Conta criada com sucesso", new ResponseData(user.Id, user.Name, user.Email.Address));
        }
    }
}

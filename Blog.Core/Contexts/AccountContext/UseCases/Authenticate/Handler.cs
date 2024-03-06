using Blog.Core.Contexts.AccountContext.Entities;
using Blog.Core.Contexts.AccountContext.UseCases.Authenticate.Contracts;
using MediatR;
using SecureIdentity.Password;

namespace Blog.Core.Contexts.AccountContext.UseCases.Authenticate
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
                    return new Response("Requisição invalida", 400, res.Notifications);
                }
            }
            catch
            {
                return new Response("Requisição não processada", 500);
            }

            User? user;

            try
            {
                user = await _repository.GetUserByEmailAsync(request.Email, cancellationToken);

                if (user is null)
                    return new Response("Perfil não encontrado", 404);
            }
            catch (Exception)
            {
                return new Response("Não foi possivel recuperar o perfil", 500);
            }

            if (!PasswordHasher.Verify(user.Password.Hash, request.Password))
            {
                return new Response("Usuario ou senha invalido", 400);
            }

            try
            {
                var data = new ResponseData
                {
                    Id = user.Id.ToString(),
                    Name = user.Name,
                    Email = user.Email.Address,
                };

                return new Response(string.Empty, data);
            }
            catch 
            {
                return new Response("Não foi possivel obter dados do perfil", 500);
            }
        }
    }
}

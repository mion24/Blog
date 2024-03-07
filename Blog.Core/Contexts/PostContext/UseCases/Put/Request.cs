using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Contexts.PostContext.UseCases.Put
{
    public record Request(Guid Id, string Title, string Description) : IRequest<Response>;
}

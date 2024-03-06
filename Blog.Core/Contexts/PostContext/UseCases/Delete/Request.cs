using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Contexts.PostContext.UseCases.Delete
{
    public record Request(string Id) : IRequest<Response>;
}

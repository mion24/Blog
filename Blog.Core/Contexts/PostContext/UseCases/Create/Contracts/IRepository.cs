using Blog.Core.Contexts.AccountContext.Entities;
using Blog.Core.Contexts.PostContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Contexts.PostContext.UseCases.Create.Contracts
{
    public interface IRepository
    {
        Task SaveAsync(Post post, CancellationToken cancellationToken);
    }
}

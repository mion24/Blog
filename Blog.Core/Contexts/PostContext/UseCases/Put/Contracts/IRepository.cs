using Blog.Core.Contexts.PostContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Contexts.PostContext.UseCases.Put.Contracts
{
    public interface IRepository
    {
        Task<Post?> GetPost(Guid id, CancellationToken cancellationToken);

        Task PutPost(Post post, CancellationToken cancellationToken);
    }
}

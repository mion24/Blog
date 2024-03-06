using Blog.Core.Contexts.PostContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Contexts.PostContext.UseCases.Delete.Contracts
{
    public interface IRepository
    {
        Task Delete(Post post);
        Task<Post?> GetPost(Guid id, CancellationToken cancellationToken);
    }
}

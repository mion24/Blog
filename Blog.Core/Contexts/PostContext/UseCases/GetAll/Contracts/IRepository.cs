using Blog.Core.Contexts.PostContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Contexts.PostContext.UseCases.GetAll.Contracts
{
    public interface IRepository
    {
        Task<List<Post>> GetAllAsync(CancellationToken cancellationToken);
    }
}

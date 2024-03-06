using Blog.Core.Contexts.PostContext.Entities;
using Blog.Core.Contexts.PostContext.UseCases.GetAll.Contracts;
using Blog.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Contexts.PostContext.UseCases.GetAll
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Posts.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
        }
    }
}

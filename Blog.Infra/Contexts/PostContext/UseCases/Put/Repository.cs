using Blog.Core.Contexts.PostContext.Entities;
using Blog.Core.Contexts.PostContext.UseCases.Put.Contracts;
using Blog.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Contexts.PostContext.UseCases.Put
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task PutPost(Post post, CancellationToken cancellationToken)
        {
             _context.Update(post);
            await _context.SaveChangesAsync();
        }

        async Task<Post?> IRepository.GetPost(Guid id, CancellationToken cancellationToken)
            => await _context.Posts.FindAsync(id);


    }
}

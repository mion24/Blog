using Blog.Core.Contexts.PostContext.Entities;
using Blog.Core.Contexts.PostContext.UseCases.Delete.Contracts;
using Blog.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Contexts.PostContext.UseCases.Delete
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Post post)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task<Post?> GetPost(Guid id, CancellationToken cancellationToken)
         => await _context.Posts.FindAsync(id);


    }
}

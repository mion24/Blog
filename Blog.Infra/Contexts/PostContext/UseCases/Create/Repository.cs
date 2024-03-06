using Blog.Core.Contexts.PostContext.Entities;
using Blog.Core.Contexts.PostContext.UseCases.Create.Contracts;
using Blog.Infra.Data;

namespace Blog.Infra.Contexts.PostContext.UseCases.Create
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(Post post, CancellationToken cancellationToken)
        {
            await _context.Posts.AddAsync(post, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

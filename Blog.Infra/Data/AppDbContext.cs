using Blog.Core.Contexts.AccountContext.Entities;
using Blog.Core.Contexts.PostContext.Entities;
using Blog.Infra.Contexts.AccountContext.Mappings;
using Blog.Infra.Contexts.PostContext.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public AppDbContext()
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());
        }
    }
}
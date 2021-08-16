using Microsoft.EntityFrameworkCore;
using ZemogaTest.Domain.Models;

namespace ZemogaTest.Repository.DatabaseContext
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

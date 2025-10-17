using Microsoft.EntityFrameworkCore;
using Blog_api.Models;

namespace Blog_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasQueryFilter(b => b.DeletedAt == null);

            base.OnModelCreating(modelBuilder);
        }
    }
}

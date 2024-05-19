using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;


namespace MyApp.Infrastructure
{
    public  class AppDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

    }
}

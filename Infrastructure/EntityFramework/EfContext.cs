using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.EfContext
{
    public class EfContext : DbContext
    {
        public EfContext(DbContextOptions<EfContext> options) : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
    }
}
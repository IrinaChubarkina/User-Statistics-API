using System.Reflection;
using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.EntityFramework
{
    public class EfContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory =
            LoggerFactory.Create(c => c.AddConsole());
        
        public EfContext(DbContextOptions<EfContext> options) : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
    }
}
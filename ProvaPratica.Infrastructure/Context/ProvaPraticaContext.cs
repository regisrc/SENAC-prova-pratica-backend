using Microsoft.EntityFrameworkCore;
using ProvaPratica.Domain.Entities;

namespace ProvaPratica.Infrastructure.Context
{
    public class ProvaPraticaContext : DbContext
    {
        public ProvaPraticaContext(DbContextOptions options) : base(options) { }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

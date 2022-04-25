using Example.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Example.Domain
{
    public class ExampleContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=localhost;Database=example;Integrated Security=True");
    }
}
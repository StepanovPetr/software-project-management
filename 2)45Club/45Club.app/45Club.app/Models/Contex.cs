using _45Club.app.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _45Club.app.Models
{
    public class Contex : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=example;SearchPath=45club;Username=postgres;Password=postgres");
    }
}
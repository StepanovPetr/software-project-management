using _45Club.app.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _45Club.app.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        { }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Transport> Transports { get; set; }

        public DbSet<Work> Work { get; set; }

        public DbSet<Owners> Owners { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql(Configuration);
    }
}
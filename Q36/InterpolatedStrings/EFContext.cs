using Microsoft.EntityFrameworkCore;

namespace InterpolatedStrings
{
    class EFContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("database.db");
    }
}

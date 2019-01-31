using Microsoft.EntityFrameworkCore;

namespace LinqQueryExecution
{
    public class PersonContext : DbContext
    {
        public PersonContext() { }

        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        { }

        // maps to the Persons table in database
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Persons.db");
        }
    }

}

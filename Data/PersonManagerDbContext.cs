using Details.Models;
using Microsoft.EntityFrameworkCore;

namespace Details.Data
{
    public class PersonManagerDbContext : DbContext
    {
        public PersonManagerDbContext(DbContextOptions<PersonManagerDbContext>options):base(options)
        {
            
        }

        public DbSet<Person> Person { get; set; }
    }
}

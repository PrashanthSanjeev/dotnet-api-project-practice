using Details.Data;
using Details.Models;

namespace Details
{
    public class Populate
    {
        private readonly PersonManagerDbContext _context;
        public Populate(PersonManagerDbContext dbcontext)
        {
            _context = dbcontext; 
        }

        public void PopulateData()
        {
            if(!_context.Person.Any())
            {

                var Persons = new List<Person>()
                {
                    new Person()
                    {
                        
                        FirstName = "Prashanth",
                        LastName = "Sanjeev",
                        Address = "KKP",
                        Email = "Prashanthnani1207@gmail.com",
                        PhoneNumber=1234323,
                    },
                    new Person()
                    {
                        
                        FirstName = "Lakshmi",
                        LastName = "Devi",
                        Address = "Kbhp",
                        Email = "LakshmiDevi@gmail.com",
                        PhoneNumber=2122122,
                    },
                      new Person()
                    {
                        
                        FirstName = "Maharsh",
                        LastName = "Rajini",
                        Address = "Lokeshnagar",
                        Email = "MaheshRajini@gmail.com",
                        PhoneNumber=2122122,
                    },

                };

                _context.Person.AddRange(Persons);
                _context.SaveChanges(); 
            }

        }
    }
}

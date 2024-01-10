using Details.Data;
using Details.Models;
using Microsoft.AspNetCore.Mvc;

namespace Details.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonManagerDbContext _context;

        public PersonController(PersonManagerDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.header = "Persons";
            return View(_context.Person);
        }

        [HttpGet]
        public IActionResult GetPersons()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if (ModelState.IsValid) { 
            _context.Person.Add(person);
            _context.SaveChanges();
            return RedirectToAction("Index");
            }
            return View();
        }
    }
}

using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalApi.Models;

namespace ClinicalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // Declaring rh database context on private and read only
        private readonly ClinicalApiContext _context;

        public PersonController(ClinicalApiContext context)
        {
            _context = context;

            if (_context.Persons.Count() == 0)
            {
                // Create a new Person if in the collection none is found,
                // which means you can't delete all Persons.
                _context.Persons.Add(new Person { personId = 1, personName = "Doe", personSurname = "John", personAdress = "DoeVille", personBirthDate = DateTime.Now, personGender = "Male", personNIC = " 1 8569 1980 00658 ", personMaritalStatus = "Maried", personEmail = "john@doe.axe" });
                _context.SaveChanges();
            }
        }

        // GET: api/<controller>. Gets all persons and attributes from database via an asynchronous action
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonsAsync()
        {
            // Awaiting for context to retrieve all informations on database at asynchronous state
            return await _context.Persons.ToListAsync();
        }

        // GET: api/<controller>/5. Gets the specified indexed person
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPersonAsync(int id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }
    }
}
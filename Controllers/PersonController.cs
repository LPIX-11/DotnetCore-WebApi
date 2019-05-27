using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApi.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase {
        // Declaring clinicalApi database context on private and read only
        private ClinicalApiContext _context = new ClinicalApiContext ();

        // On Construcor Call
        public PersonController () {

            if (_context.Persons.Count () == 0) {
                // Create a new Person if in the collection none is found,
                // which means you can't delete all Persons.
                _context.Persons.Add (new Person { personName = "Doe", personSurname = "John", personAdress = "DoeVille", personBirthDate = DateTime.Now, personGender = "Male", personNIC = " 1 8569 1980 00658 ", personMaritalStatus = "Maried", personEmail = "john@doe.axe" });
                _context.SaveChanges ();
            }
        }

        // GET: api/<controller>. Gets all persons and attributes from database via an asynchronous action
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonsAsync () {
            // Awaiting for context to retrieve all informations on database at asynchronous state
            return await _context.Persons.ToListAsync ();
        }

        // GET: api/<controller>/5. Gets the specified indexed person
        [HttpGet ("{id}")]
        public async Task<ActionResult<Person>> GetPersonAsync (int id) {
            var person = await _context.Persons.FindAsync (id);

            if (person == null) {
                return NotFound (); // Returning an not found exception when there's no person with the specified id
                // NotFound returns a 404 status as an answer
            }

            return person; // Returning the specified person
        }

        // POST: api/<controller>. Post a new person from form body to the database
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson ([FromBody] Person person) {
            // Adding the person object to the database
            _context.Persons.Add (person);
            await _context.SaveChangesAsync (); // ReSynchronizing the database just after insertion

            return CreatedAtAction (nameof (GetPersonAsync), new { id = person.personId }, person); // return the created action
        }

        // PUT api/<controller>/5
        [HttpPut ("{idperson}")]
        public async Task<IActionResult> PutPerson (int idperson, [FromBody] Person person) {
            if (idperson != person.personId) {
                return BadRequest ();
            }

            _context.Entry (person).State = EntityState.Modified;
            await _context.SaveChangesAsync ();

            return NoContent ();
        }

        /*
         * Commenting out the delete method, think it's not necessary for now 15/03/2019
         */

        // DELETE api/<controller>/5
        [Route ("remove/{idperson}")]
        [HttpDelete ("{idperson}")]
        public async Task<IActionResult> DeletePersonAsync (int idperson) {
            var person = await _context.Persons.FindAsync (idperson);
            if (person == null) {
                return NotFound ();
            }
            _context.Persons.Remove (person);
            await _context.SaveChangesAsync ();
            return NoContent ();
        }
    }
}
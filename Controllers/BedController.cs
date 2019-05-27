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
    public class BedController : ControllerBase {
        // Declaring clinicalApi database context on private and read only
        private ClinicalApiContext _context = new ClinicalApiContext ();

        public BedController () {
            if (_context.Beds.Count () == 0) {
                // Not finished
                if (_context.Rooms.Count () == 0) {
                    _context.Rooms.Add (new Room { roomCode = "rm123", roomName = "DoeRoom" });
                }
                // _context.Beds.Add (new Bed { bedCode = "br123 ", roomId = room.roomId, room = room });
            }
        }

        // GET: api/<controller>. Gets all beds and attributes from database via an asynchronous action
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bed>>> GetbedsAsync () {
            // Awaiting for context to retrieve all informations on database at asynchronous state
            return await _context.Beds.ToListAsync ();
        }

        // GET: api/<controller>/5. Gets the specified indexed Bed
        [HttpGet ("{id}")]
        public async Task<ActionResult<Bed>> GetBedAsync (int id) {
            var Bed = await _context.Beds.FindAsync (id);

            if (Bed == null) {
                return NotFound (); // Returning an not found exception when there's no Bed with the specified id
                // NotFound returns a 404 status as an answer
            }

            return Bed; // Returning the specified Bed
        }

        // POST: api/<controller>. Post a new Bed from form body to the database
        [HttpPost]
        public async Task<ActionResult<Bed>> PostBed ([FromBody] Bed Bed) {
            // Adding the Bed object to the database
            _context.Beds.Add (Bed);
            await _context.SaveChangesAsync (); // ReSynchronizing the database just after insertion

            return CreatedAtAction (nameof (GetBedAsync), new { id = Bed.bedId }, Bed); // return the created action
        }

        // PUT api/<controller>/5
        [HttpPut ("{idBed}")]
        public async Task<IActionResult> PutBed (int idBed, [FromBody] Bed Bed) {
            if (idBed != Bed.bedId) {
                return BadRequest ();
            }

            _context.Entry (Bed).State = EntityState.Modified;
            await _context.SaveChangesAsync ();

            return NoContent ();
        }

        /*
         * Commenting out the delete method, think it's not necessary for now 25/03/2019
         */

        // DELETE api/<controller>/5
        [Route ("remove/{idBed}")]
        [HttpDelete ("{idBed}")]
        public async Task<IActionResult> DeleteBedAsync (int idBed) {
            var Bed = await _context.Beds.FindAsync (idBed);
            if (Bed == null) {
                return NotFound ();
            }
            _context.Beds.Remove (Bed);
            await _context.SaveChangesAsync ();
            return NoContent ();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using flightpath.api.Models;

namespace flightpath.api.Controllers
{
    [Produces("application/json")]
    [Route("api/aircraft")]
    public class AircraftController : ControllerBase
    {
        private readonly AeroContext _context;

        public AircraftController(AeroContext context)
        {
            _context = context;
        }

        // GET: api/Aircraft
        [HttpGet]
        public async Task<IEnumerable<Aircraft>> GetAircraft()
        {
            return await Task.Run(() =>_context.Aircraft);
        }

        [HttpGet("{make}/{model}")]
        public async Task<IEnumerable<Aircraft>> GetAircraft(string make, string model)
        {
            return await Task.Run(() => _context.Aircraft.Where(x => x.Make == make && x.Model.Contains(model)));
        }

        // GET: api/Aircraft/5
        [HttpGet("{id}")]
        [Produces(typeof(Aircraft))]
        public async Task<IActionResult> GetAircraft([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aircraft = await _context.Aircraft.SingleOrDefaultAsync(m => m.Id == id);

            if (aircraft == null)
            {
                return NotFound();
            }

            return Ok(aircraft);
        }

        // PUT: api/Aircraft/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAircraft([FromRoute] int id, [FromBody] Aircraft aircraft)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aircraft.Id)
            {
                return BadRequest();
            }

            _context.Entry(aircraft).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AircraftExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Aircraft
        [HttpPost]
        public async Task<IActionResult> PostAircraft([FromBody] Aircraft aircraft)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Aircraft.Add(aircraft);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AircraftExists(aircraft.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAircraft", new { id = aircraft.Id }, aircraft);
        }

        // DELETE: api/Aircraft/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAircraft([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aircraft = await _context.Aircraft.SingleOrDefaultAsync(m => m.Id == id);
            if (aircraft == null)
            {
                return NotFound();
            }

            _context.Aircraft.Remove(aircraft);
            await _context.SaveChangesAsync();

            return Ok(aircraft);
        }

        private bool AircraftExists(int id)
        {
            return _context.Aircraft.Any(e => e.Id == id);
        }
    }
}
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
    [Route("api/airport")]
    public class AirportsController : ControllerBase
    {
        private readonly AeroContext _context;

        public AirportsController(AeroContext context)
        {
            _context = context;
        }

        // GET: api/Airports
        [HttpGet]
        public async Task<IEnumerable<Airport>> GetAirport()
        {
            return await Task.Run(() => _context.Airport);
        }

        // GET: api/Airports/5
        [HttpGet("{designator}")]
        [Produces(typeof(Airport))]
        public async Task<IActionResult> GetAirport([FromRoute] string designator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var airport = await _context.Airport.SingleOrDefaultAsync(m => m.Designator == designator);

            if (airport == null)
            {
                return NotFound();
            }

            return Ok(airport);
        }

        // PUT: api/Airports/5
        [HttpPut("{designator}")]
        public async Task<IActionResult> PutAirport([FromRoute] string designator, [FromBody] Airport airport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (designator != airport.Designator)
            {
                return BadRequest();
            }

            _context.Entry(airport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirportExists(designator))
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

        // POST: api/Airports
        [HttpPost]
        public async Task<IActionResult> PostAirport([FromBody] Airport airport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Airport.Add(airport);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AirportExists(airport.Designator))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAirport", new { id = airport.Designator }, airport);
        }

        // DELETE: api/Airports/5
        [HttpDelete("{designator}")]
        public async Task<IActionResult> DeleteAirport([FromRoute] string designator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var airport = await _context.Airport.SingleOrDefaultAsync(m => m.Designator == designator);
            if (airport == null)
            {
                return NotFound();
            }

            _context.Airport.Remove(airport);
            await _context.SaveChangesAsync();

            return Ok(airport);
        }

        private bool AirportExists(string designator)
        {
            return _context.Airport.Any(e => e.Designator == designator);
        }
    }
}
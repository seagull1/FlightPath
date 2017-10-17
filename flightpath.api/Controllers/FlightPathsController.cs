using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using flightpath.api.Models;
using flightpath.api.Utils;
using flightpath.api.Interface;

namespace flightpath.api.Controllers
{
    [Produces("application/json")]
    [Route("api/flightpath")]
    public class FlightPathsController : ControllerBase
    {
        private readonly AeroContext _context;
        private readonly IRouteOptimizeRepository _routeOptimizeRepository;

        public FlightPathsController(AeroContext context, IRouteOptimizeRepository routeOptimizeRepository)
        {
            _context = context;
            _routeOptimizeRepository = routeOptimizeRepository;

        }

        [HttpPost]
        public async Task<IActionResult> GetOptimizedRoute([FromBody]SearchCriteria criteris)
        {
            if (criteris.AircraftId == 0 || string.IsNullOrEmpty(criteris.StartAirportCode) || string.IsNullOrEmpty(criteris.EndAirportCode))
                BadRequest("Aircraft ID, departure and arrival airort needed.");

            var routes = await Task.Run(() => _routeOptimizeRepository.OptimizeRoute(criteris));

            if (routes == null)
            {
                return NotFound();
            }

            return Ok(routes);
        }

       

    }
}
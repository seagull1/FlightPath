using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlightPath.Application.Route.Queries;
using System.Threading.Tasks;

namespace FlightPath.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AirportDtosListViewModel>> Get([FromQuery] GetAirportDtosListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlightPath.Application.Airports.Commands;
using FlightPath.Application.Airports.Queries;
using System.Threading.Tasks;

namespace FlightPath.Api.Controllers
{
    public class AirportController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AirportsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAirportsListQuery()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AirportDetailModel>> Get(string id)
        {
            return Ok(await Mediator.Send(new GetAirportDetailQuery { Designator = id }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateAirportCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody]UpdateAirportCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteAirportCommand { Designator = id });

            return NoContent();
        }
    }
}
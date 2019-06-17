using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlightPath.Application.Aircrafts.Commands;
using FlightPath.Application.Aircrafts.Queries;
using System.Threading.Tasks;

namespace FlightPath.Api.Controllers
{  
    public class AircraftController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AircraftsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAircraftsListQuery()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AircraftDetailModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetAircraftDetailQuery { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateAircraftCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody]UpdateAircraftCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteAircraftCommand { Id = id });

            return NoContent();
        }
    }
}
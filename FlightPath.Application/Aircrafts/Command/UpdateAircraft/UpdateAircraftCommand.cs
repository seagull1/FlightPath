using MediatR;
using Microsoft.EntityFrameworkCore;
using FlightPath.Application.Exceptions;
using FlightPath.Application.Interfaces;
using FlightPath.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;


namespace FlightPath.Application.Aircrafts.Commands
{
    public class UpdateAircraftCommand : IRequest
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int FuelCapacity { get; set; }
        public int SpeedCruise { get; set; }
        public int Range { get; set; }
        public int Ceiling { get; set; }
        public int? Horsepower { get; set; }
        public int? WeightEmpty { get; set; }
        public int? WeightGross { get; set; }
        public int? SpeedTop { get; set; }
        public int? SpeedStall { get; set; }
        public int? TakeoffGroundRoll { get; set; }
        public int? LandingGroundRoll { get; set; }
        public int? Takeoff50ftObst { get; set; }
        public int? Landing50ftObst { get; set; }
        public int? RateOfClimb { get; set; }
        public int? RateOfClimbSingle { get; set; }
        public int? CeilingSingle { get; set; }
        public int? FuelBurn { get; set; }

        public class Handler : IRequestHandler<UpdateAircraftCommand, Unit>
        {
            private readonly IFlightPathDbContext _context;

            public Handler(IFlightPathDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateAircraftCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Aircraft
                    .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Aircraft), request.Id);
                }

                entity.Make = request.Make;
                entity.Model = request.Model;
                entity.FuelCapacity = request.FuelCapacity;
                entity.SpeedCruise = request.SpeedCruise;
                entity.Range = request.Range;
                entity.Ceiling = request.Ceiling;
                entity.Horsepower = request.Horsepower;
                entity.WeightEmpty = request.WeightEmpty;
                entity.WeightGross = request.WeightGross;
                entity.SpeedTop = request.SpeedTop;
                entity.SpeedStall = request.SpeedStall;
                entity.TakeoffGroundRoll = request.TakeoffGroundRoll;
                entity.LandingGroundRoll = request.LandingGroundRoll;
                entity.Takeoff50ftObst = request.Takeoff50ftObst;
                entity.Landing50ftObst = request.Landing50ftObst;
                entity.RateOfClimb = request.RateOfClimb;
                entity.RateOfClimbSingle = request.RateOfClimbSingle;
                entity.CeilingSingle = request.WeightGross;
                entity.FuelBurn = request.FuelBurn;

                //await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

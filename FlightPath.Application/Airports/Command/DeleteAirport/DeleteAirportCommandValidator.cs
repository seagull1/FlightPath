using FluentValidation;

namespace FlightPath.Application.Airports.Commands
{
    public class DeleteAirportCommandValidator : AbstractValidator<DeleteAirportCommand>
    {
        public DeleteAirportCommandValidator()
        {
            RuleFor(v => v.Designator).NotEmpty().MaximumLength(5);
        }
    }
}

using FluentValidation;

namespace FlightPath.Application.Airports.Commands
{
    public class UpdateAirportCommandValidator : AbstractValidator<UpdateAirportCommand>
    {
        public UpdateAirportCommandValidator()
        {
            RuleFor(x => x.AirportName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Designator).NotEmpty().MaximumLength(5);
            RuleFor(x => x.Category).MaximumLength(40);
            RuleFor(x => x.City).MaximumLength(50);
            RuleFor(x => x.Province).MaximumLength(50);
            RuleFor(x => x.Country).NotEmpty().MaximumLength(45);
        }
    }
}

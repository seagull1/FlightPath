using FluentValidation;

namespace FlightPath.Application.Aircrafts.Commands
{
    public class CreateAircraftCommandValidator : AbstractValidator<CreateAircraftCommand>
    {
        public CreateAircraftCommandValidator()
        {            
            RuleFor(x => x.Make).MaximumLength(40);
            RuleFor(x => x.Model).MaximumLength(60);
            RuleFor(x => x.FuelCapacity).NotEmpty();
            RuleFor(x => x.SpeedCruise).NotEmpty();
            RuleFor(x => x.Ceiling).NotEmpty();
            RuleFor(x => x.Range).NotEmpty();
        }
    }
}

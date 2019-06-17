using FluentValidation;

namespace FlightPath.Application.Aircrafts.Commands
{ 
    public class DeleteAircraftCommandValidator : AbstractValidator<DeleteAircraftCommand>
    {
        public DeleteAircraftCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}

using FluentValidation;

namespace FlightPath.Application.Aircrafts.Queries
{
    public class GetAircraftDetailQueryValidator : AbstractValidator<GetAircraftDetailQuery>
    {
        public GetAircraftDetailQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}

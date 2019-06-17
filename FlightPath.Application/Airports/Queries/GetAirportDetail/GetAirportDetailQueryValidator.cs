using FluentValidation;

namespace FlightPath.Application.Airports.Queries
{
    public class GetAirportDetailQueryValidator : AbstractValidator<GetAirportDetailQuery>
    {
        public GetAirportDetailQueryValidator()
        {
            RuleFor(v => v.Designator).NotEmpty().MaximumLength(5);
        }
    }
}

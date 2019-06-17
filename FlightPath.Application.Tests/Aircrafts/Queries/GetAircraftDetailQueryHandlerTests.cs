using FlightPath.Application.Aircrafts.Queries;
using FlightPath.Application.Tests.Infrastructure;
using FlightPath.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FlightPath.Application.Tests.Aircrafts.Queries
{
    [Collection("QueryCollection")]
    public class GetAircraftDetailQueryHandlerTests
    {
        private readonly FlightPathDbContext _context;

        public GetAircraftDetailQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task GetAircraftDetail()
        {
            var sut = new GetAircraftDetailQueryHandler(_context);

            var result = await sut.Handle(new GetAircraftDetailQuery { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<AircraftDetailModel>();
            result.Id.ShouldBe(1);
        }
    }
}

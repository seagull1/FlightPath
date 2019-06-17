using AutoMapper;
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
    public class GetAircraftsListQueryHandlertests
    {
        private readonly FlightPathDbContext _context;
        private readonly IMapper _mapper;

        public GetAircraftsListQueryHandlertests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetAircraftsTest()
        {
            var sut = new GetAircraftsListQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetAircraftsListQuery(), CancellationToken.None);

            result.ShouldBeOfType<AircraftsListViewModel>();

            result.Aircrafts.Count.ShouldBe(2);
        }
    }
}

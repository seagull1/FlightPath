using System;
using AutoMapper;
using FlightPath.Persistence;
using Xunit;


namespace FlightPath.Application.Tests.Infrastructure
{
    public class QueryTestFixture : IDisposable
    {
        public FlightPathDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = FlightPathContextFactory.Create();
            Mapper = AutoMapperFactory.Create();
        }

        public void Dispose()
        {
            FlightPathContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}

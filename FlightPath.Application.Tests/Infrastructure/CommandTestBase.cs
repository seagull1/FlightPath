using System;
using FlightPath.Persistence;

namespace FlightPath.Application.Tests.Infrastructure
{
    public class CommandTestBase : IDisposable
    {
        protected readonly FlightPathDbContext _context;

        public CommandTestBase()
        {
            _context = FlightPathContextFactory.Create();
        }

        public void Dispose()
        {
            FlightPathContextFactory.Destroy(_context);
        }
    }
}

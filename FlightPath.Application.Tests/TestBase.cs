using Microsoft.EntityFrameworkCore;
using System;
using FlightPath.Persistence;

namespace FlightPath.Application.Tests
{
    class TestBase
    {
        public FlightPathDbContext GetDbContext(bool useSqlServer = false)
        {
            var builder = new DbContextOptionsBuilder<FlightPathDbContext>();
            if (useSqlServer)
            {
                builder.UseSqlServer("DataSource=:memory:", x => { });
            }
            else
            {
                builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            }

            var dbContext = new FlightPathDbContext(builder.Options);
            if (useSqlServer)
            {
                // SQ needs to open connection to the DB.
                // Not required for in-memory-database.
                dbContext.Database.OpenConnection();
            }

            dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}

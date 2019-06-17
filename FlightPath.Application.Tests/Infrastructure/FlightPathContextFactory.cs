using System;
using Microsoft.EntityFrameworkCore;
using FlightPath.Domain.Entities;
using FlightPath.Persistence;

namespace FlightPath.Application.Tests.Infrastructure
{
    public class FlightPathContextFactory
    {
        public static FlightPathDbContext Create()
        {
            var options = new DbContextOptionsBuilder<FlightPathDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new FlightPathDbContext(options);

            context.Database.EnsureCreated();

            context.Aircraft.AddRange(new[] {
                new Aircraft { Id = 1, Make  = "test1", Model = "New Model 1",
                    FuelCapacity = 100, SpeedCruise = 500, Range = 600,
                    Ceiling = 3000},

                new Aircraft { Id = 2, Make  = "test2", Model = "New Model ",
                    FuelCapacity = 100, SpeedCruise = 500, Range = 600,
                    Ceiling = 3000},
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(FlightPathDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}

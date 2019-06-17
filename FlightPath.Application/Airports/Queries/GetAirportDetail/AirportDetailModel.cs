using System;
using System.Linq.Expressions;
using FlightPath.Domain.Entities;

namespace FlightPath.Application.Airports.Queries
{
    public class AirportDetailModel
    {
        public string AirportName { get; set; }
        public bool Icao { get; set; }
        public string Designator { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Elevation { get; set; }

        public static Expression<Func<Airport, AirportDetailModel>> Projection
        {
            get
            {
                return aircraft => new AirportDetailModel
                {
                   AirportName = aircraft.AirportName,
                   Icao = aircraft.Icao,
                   Designator = aircraft.Designator,
                   Category = aircraft.Category,
                   City = aircraft.City,
                   Province = aircraft.Province,
                   Country = aircraft.Country,
                   Latitude = aircraft.Latitude,
                   Longitude = aircraft.Longitude,
                   Elevation = aircraft.Elevation
                };
            }
        }

        public static AirportDetailModel Create(Airport airport)
        {
            return Projection.Compile().Invoke(airport);
        }
    }
}

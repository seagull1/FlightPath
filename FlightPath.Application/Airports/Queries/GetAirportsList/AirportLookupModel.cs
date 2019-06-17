using AutoMapper;
using FlightPath.Application.Interfaces.Mapping;
using FlightPath.Domain.Entities;

namespace FlightPath.Application.Airports.Queries
{
    public class AirportLookupModel : IHaveCustomMapping
    {
        public string AirportName { get; set; }
        public string Designator { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Airport, AirportLookupModel>()
              .ForMember(cDTO => cDTO.AirportName, opt => opt.MapFrom(c => c.AirportName))
              .ForMember(cDTO => cDTO.Designator, opt => opt.MapFrom(c => c.Designator));
        }
     }
}

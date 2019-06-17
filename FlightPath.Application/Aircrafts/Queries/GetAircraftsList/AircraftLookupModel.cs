using AutoMapper;
using FlightPath.Application.Interfaces.Mapping;
using FlightPath.Domain.Entities;

namespace FlightPath.Application.Aircrafts.Queries
{
    public class AircraftLookupModel : IHaveCustomMapping
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int FuelCapacity { get; set; }
        public int SpeedCruise { get; set; }
        public int Range { get; set; }
        public int Ceiling { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Aircraft, AircraftLookupModel>()
              .ForMember(cDTO => cDTO.Id, opt => opt.MapFrom(c => c.Id))
              .ForMember(cDTO => cDTO.Make, opt => opt.MapFrom(c => c.Make))
              .ForMember(cDTO => cDTO.Model, opt => opt.MapFrom(c => c.Model))
              .ForMember(cDTO => cDTO.FuelCapacity, opt => opt.MapFrom(c => c.FuelCapacity))
              .ForMember(cDTO => cDTO.SpeedCruise, opt => opt.MapFrom(c => c.SpeedCruise))
              .ForMember(cDTO => cDTO.Range, opt => opt.MapFrom(c => c.Range))
              .ForMember(cDTO => cDTO.Ceiling, opt => opt.MapFrom(c => c.Ceiling));
        }
    }
}

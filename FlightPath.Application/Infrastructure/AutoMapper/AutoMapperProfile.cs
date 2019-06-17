using AutoMapper;
using System.Reflection;

namespace FlightPath.Application.Infrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            LoadStandardMappings();
            LoadAirportMappings();
            LoadAircraftMappings();
            LoadConverters();
        }

        private void LoadConverters()
        {

        }

        private void LoadStandardMappings()
        {
            var mapsFrom = MapperProfileHelper.LoadStandardMappings(Assembly.GetExecutingAssembly());

            foreach (var map in mapsFrom)
            {
                CreateMap(map.Source, map.Destination).ReverseMap();
            }
        }

        private void LoadAircraftMappings()
        {
            var mapsFrom = MapperProfileHelper.LoadAircraftMappings(Assembly.GetExecutingAssembly());

            foreach (var map in mapsFrom)
            {
                map.CreateMappings(this);
            }
        }

        private void LoadAirportMappings()
        {
            var mapsFrom = MapperProfileHelper.LoadAirportMappings(Assembly.GetExecutingAssembly());

            foreach (var map in mapsFrom)
            {
                map.CreateMappings(this);
            }
        }
    }
}

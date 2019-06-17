using AutoMapper;
using MediatR;
using FlightPath.Application.Interfaces;
using FlightPath.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using FlightPath.Domain.Utils;

namespace FlightPath.Application.Route.Queries
{
    public class GetAirportDtosListQueryHandler : IRequestHandler<GetAirportDtosListQuery, AirportDtosListViewModel>
    {
        private readonly IFlightPathDbContext _context;
        private readonly IMapper _mapper;

        public GetAirportDtosListQueryHandler(IFlightPathDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AirportDtosListViewModel> Handle(GetAirportDtosListQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => OptimizeRoute(
                    request.AircraftId, 
                    request.StartAirport, 
                    request.EndAirport), cancellationToken);
        }

        private AirportDtosListViewModel OptimizeRoute(int aircraftId, string startAirport, string endAirport)
        {
            var aircraft = _context.Aircraft.SingleOrDefault(x => x.Id == aircraftId);

            var startNode = GetAirportDto(startAirport);

            var endNode = GetAirportDto(endAirport);

            if (aircraft == null || startNode == null || endNode == null) return null;

            var startLat = startNode.Latitude;
            var startLng = startNode.Longitude;
            var endLat = endNode.Latitude;
            var endLng = endNode.Longitude;
            var range = aircraft.Range;
            var shortestNodes = new List<AirportDto>();
            var distance = DistanceCalculator.GetDistance(startNode.Latitude, startNode.Longitude, endNode.Latitude, endNode.Longitude);
            startNode.LengthMiddleEnd = distance;
            endNode.LengthStartMiddle = distance;
            shortestNodes.Add(startNode);
            if (distance > range)
            {
                var openNodes = GetAirportsWithRunway(aircraft).ToList();
                var closeNodes = new List<AirportDto>();
                var end = false;
                do
                {
                    foreach (var node in openNodes)
                    {
                        node.LengthStartMiddle = DistanceCalculator.GetDistance(startLat, startLng, node.Latitude, node.Longitude);
                        if ((node.LengthStartMiddle <= range) && (node.Id != startNode.Id))
                            closeNodes.Add(node);
                    }
                    if (closeNodes.Count == 0)
                    {
                        end = true;
                        endNode.Name = "No reachable airport found";
                    }
                    else
                    {
                        foreach (var node in closeNodes)
                        {
                            node.LengthMiddleEnd = DistanceCalculator.GetDistance(node.Latitude, node.Longitude, endLat, endLng);
                        }
                        closeNodes.Sort(AirportDto.GetComparer(AirportDto.SortField.LengthMiddleEnd, SortDirection.Ascending));
                        shortestNodes.Add(closeNodes[0]);
                        if (closeNodes[0].LengthMiddleEnd <= range)
                            end = true;

                        startLat = closeNodes[0].Latitude;
                        startLng = closeNodes[0].Longitude;
                    }
                    closeNodes.Clear();
                    openNodes.RemoveAll(x => x.LengthStartMiddle <= range);

                } while (end != true);
                openNodes.Clear();
            }
            shortestNodes.Add(endNode);

            return new AirportDtosListViewModel
                    {
                        AirportDtos = shortestNodes
                    };
        }

        private AirportDto GetAirportDto(string airportId)
        {
            var airport = _context.Airport.SingleOrDefault(x => x.Designator == airportId);

            if (airport == null) return null;

            return new AirportDto
            {
                Id = airport.Designator,
                Name = airport.AirportName,
                Latitude = airport.Latitude,
                Longitude = airport.Longitude
            };
        }

        private IEnumerable<AirportDto> GetAirportsWithRunway(Aircraft aircraft)
        {
            var airports = _context.Airport.Where(
                x =>
                    x.Runway.Any(
                        r =>
                            r.RunwayLength >= aircraft.LandingGroundRoll &&
                            r.RunwayLength >= aircraft.TakeoffGroundRoll));

            if (!airports.Any()) return null;

            return airports.Select(x => new AirportDto
            {
                Id = x.Designator,
                Name = x.AirportName,
                Latitude = x.Latitude,
                Longitude = x.Longitude
            });
        }
    }
}

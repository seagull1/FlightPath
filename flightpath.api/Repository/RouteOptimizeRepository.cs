using flightpath.api.Interface;
using flightpath.api.Models;
using flightpath.api.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flightpath.api.Repository
{
    public class RouteOptimizeRepository : IRouteOptimizeRepository
    {
        private readonly AeroContext _context;

        public RouteOptimizeRepository(AeroContext aeroContext)
        {
            _context = aeroContext;
        }

        public IEnumerable<AirportDto> OptimizeRoute(SearchCriteria criteris)
        {
            var aircraft = _context.Aircraft.SingleOrDefault(x => x.Id == criteris.AircraftId);

            var startNode = GetAirportDto(criteris.StartAirportCode);

            var endNode = GetAirportDto(criteris.EndAirportCode);

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
                    var finder = new FindNode(range);
                    openNodes.RemoveAll(finder.LengthOverRange);

                } while (end != true);
                openNodes.Clear();
            }
            shortestNodes.Add(endNode);
            return shortestNodes;
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

        private class FindNode
        {
            private readonly double _range;

            public FindNode(double range)
            {
                _range = range;
            }

            public bool LengthOverRange(AirportDto node)
            {
                return node.LengthStartMiddle <= _range;
            }
        }
    }
}

using System;
using FlightPath.Domain.ValueObjects;

namespace FlightPath.Domain.Utils
{
    /// <summary>
    /// Calculate distance between two point on earth
    /// </summary>
    public static class DistanceCalculator
    {
        private const double EarthRadius = 6378.137; //earth radius
        private const double Change = 1.852;

        private static double Rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        public static double GetDistance(Coordinate x, Coordinate y)
        {
            return GetDistance(x.Latitude, x.Longitude, y.Latitude, y.Longitude);
        }

        public static double GetDistance(double xLatitude, double xLongitude, double yLatitude, double yLongitude)
        {
            var radLat1 = Rad(xLatitude);
            var radLat2 = Rad(yLatitude);

            var a = radLat1 - radLat2;

            var b = Rad(xLongitude) - Rad(yLongitude);

            var s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
            Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));

            s *= EarthRadius;

            s = (Math.Round(s * 10000) / 10000) / Change;

            return s;

        }
    }
}

using System;
using System.Collections.Generic;
using FlightPath.Domain.Exceptions;
using FlightPath.Domain.Infrastructure;

namespace FlightPath.Domain.ValueObjects
{
    public class Coordinate : ValueObject
    {
        private Coordinate()
        {         
        }
        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public static Coordinate For(string coordinateStr)
        {
            var coordinate = new Coordinate();

            try
            {
                var index = coordinateStr.IndexOf(",", StringComparison.Ordinal);
                coordinate.Latitude = Convert.ToDouble(coordinateStr.Substring(0, index));
                coordinate.Longitude = Convert.ToDouble(coordinateStr.Substring(index + 1));
            }
            catch (Exception ex)
            {
                throw new CoordinateInvalidException(coordinateStr, ex);
            }

            return coordinate;
        }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public static implicit operator string(Coordinate coordinate)
        {
            return coordinate.ToString();
        }

        public static explicit operator Coordinate(string coordinateStr)
        {
            return For(coordinateStr);
        }

        public override string ToString()
        {
            return $"{Latitude},{Longitude}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Latitude;
            yield return Longitude;
        }
    }
}

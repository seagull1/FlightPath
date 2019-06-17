using System;

namespace FlightPath.Domain.Exceptions
{
    public class CoordinateInvalidException : Exception
    {
        public CoordinateInvalidException(string coordinate, Exception ex)
           : base($"Coordinate \"{coordinate}\" is invalid.", ex)
        {
        }
    }
}

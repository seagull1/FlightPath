using FlightPath.Domain.Exceptions;
using FlightPath.Domain.ValueObjects;
using Xunit;

namespace FlightPath.Domain.Tests.ValueObjects
{
    public class CoordinateTests
    {
        [Fact]
        public void ShouldHaveCorrectlatitudeAndLongitude()
        {
            var coordinate = Coordinate.For("0,1");

            Assert.Equal(0, coordinate.Latitude);
            Assert.Equal(1, coordinate.Longitude);
        }

        [Fact]
        public void ToStringReturnsCorrectFormat()
        {
            const string value = "0,1";

            var coordinate = Coordinate.For(value);

            Assert.Equal(value, coordinate.ToString());
        }

        [Fact]
        public void ImplicitConversionToStringResultsInCorrectString()
        {
            const string value = "0,1";

            var coordinate = Coordinate.For(value);

            string result = coordinate;

            Assert.Equal(value, result);
        }

        [Fact]
        public void ShouldThrowCoordinateInvalidExceptionForInvalidCoordinate()
        {
            Assert.Throws<CoordinateInvalidException>(() => (Coordinate)"01");
        }
    }
}

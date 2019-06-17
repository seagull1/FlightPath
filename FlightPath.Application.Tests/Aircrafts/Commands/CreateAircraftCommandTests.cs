using MediatR;
using Moq;
using FlightPath.Application.Aircrafts.Commands;
using FlightPath.Application.Tests.Infrastructure;
using System.Threading;
using Xunit;

namespace FlightPath.Application.Tests.Aircrafts.Commands
{
    public class CreateAircraftCommandTests : CommandTestBase
    {
        [Fact]
        public void Handle_GivenValidRequest_ShouldRaiseAircraftCreatedNotification()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new CreateAircraftCommand.Handler(_context, mediatorMock.Object);
            var newAircraftId = 0;

            // Act
            var result = sut.Handle(new CreateAircraftCommand
            {
                Id = 0,
                Make = "Make test",
                Model = "Model test",
                FuelCapacity = 100,
                SpeedCruise = 500,
                Ceiling = 2000,
                Range = 600
            }, CancellationToken.None);

            // Assert
            mediatorMock.Verify(m => m.Publish(It.Is<AircraftCreated>(cc => cc.AircraftId == newAircraftId), 
                It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}

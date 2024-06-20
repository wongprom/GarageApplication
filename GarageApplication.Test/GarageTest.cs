using GarageApplication.Classes.Baseclass;
using GarageApplication.Classes.Subclass;

namespace GarageApplication.Test
{
    public class GarageTest
    {
        [Fact]
        public void Garage_CreateGarageWithValidUintOfLots()
        {
            //Arrange
            uint expectedLots = 5;

            //Act
            var garage = new Garage<Vehicle>(numOfParkingLots: expectedLots);

            //Assert
            var actualNumOfParkingLots = garage.NumOfParkingLots;
            Assert.Equal((int)expectedLots, actualNumOfParkingLots);
        }

        [Fact]
        public void ParkVehicle_WhenGarageHasSpace_ShouldReturnTrue()
        {
            // Arrange
            uint expectedLots = 5;
            var garage = new Garage<Vehicle>(expectedLots);
            var vehicle = new Car("ABC123", "Red", 4, Car.FuelType.Gasoline); 

            // Act
            var result = garage.Park(vehicle);

            // Assert
            Assert.True(result);
        }

    }
}
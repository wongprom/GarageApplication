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
            var actualNumOfParkingLots = garage.NumberOfParkingLots;
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

        [Fact]
        public void ParkVehicle_WhenGarageIsFull_ShouldReturnFalse()
        {
            // Arrange
            uint lots = 4;
            var garage = new Garage<Vehicle>(lots);

            var car = new Car("ABC123", "Red", 4, Car.FuelType.Gasoline);
            var motorcycle = new Motorcycle("QWE123", "Blue", 2, 250); 
            var bus = new Bus("ASD456", "Red", 4, 6);
            var airplane = new Airplane("ZXC789", "Blue", 2, 2); 
            var boat = new Boat("LOK459", "Blue", 2, 2.9); 


            // Act: Park the first 4 vehicles
            garage.Park(car);
            garage.Park(motorcycle);
            garage.Park(bus);
            garage.Park(airplane);

            // Act: Attempt to park when garage full
            var actualResult = garage.Park(car);

            // Assert
            Assert.False(actualResult);
        }

        [Fact]
        public void Remove_VehicleFromGarage_ShouldReturnTrue()
        {
            // Arrange
            var garage = new Garage<Vehicle>(4);
            var car = new Car("ABC123", "Red", 4, Car.FuelType.Gasoline);
            var motorcycle = new Motorcycle("QWE123", "Blue", 2, 250);
            var bus = new Bus("ASD456", "Red", 4, 6);
            var airplane = new Airplane("ZXC789", "Blue", 2, 2);

            garage.Park(car);
            garage.Park(motorcycle);
            garage.Park(bus);
            garage.Park(airplane);

            // Act
            var actualResult = garage.Remove("ABC123");
            
            // Assert
            Assert.True(actualResult);
        }

        [Fact]
        public void GetVehicleByRegNum_IfRegNumExist_ShouldReturnVehicle()
        {
            // Arrange
            var garage = new Garage<Vehicle>(4);
            var car = new Car("ABC123", "Red", 4, Car.FuelType.Gasoline);
            var motorcycle = new Motorcycle("QWE123", "Blue", 2, 250);
            var bus = new Bus("ASD456", "Red", 4, 6);
            var airplane = new Airplane("ZXC789", "Blue", 2, 2);

            garage.Park(car);
            garage.Park(motorcycle);
            garage.Park(bus);
            garage.Park(airplane);

            // Act
            var actualResult = garage.GetVehicleByRegNum("ABC123");
            var expectedResult = car;

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
        
    }
}
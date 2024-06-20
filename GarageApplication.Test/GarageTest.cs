using GarageApplication.Classes.Baseclass;

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
    }
}
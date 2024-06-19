using GarageApplication.Classes.Baseclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageApplication.Program;

namespace GarageApplication.Classes.Subclass
{
    internal class Car : Vehicle
    {
        public enum FuelType { Gasoline = 1, Diesel }
        public FuelType Fuel { get; set; }

        public Car(string regNum, string color, uint numOfWheels, FuelType fuel) : base(regNum, color, numOfWheels)
        {
            Fuel = fuel;
        }
    }
}

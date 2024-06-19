using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.Classes.Baseclass
{
    public class Vehicle
    {
        public readonly string? RegNum;
        private readonly string? _color;
        private readonly uint _numOfWheels;

        public Vehicle(string regNum, string color, uint numOfWheels)
        {
            RegNum = regNum;
            _color = color;
            _numOfWheels = numOfWheels;
        }

        public Vehicle()
        {
        }
    }
}

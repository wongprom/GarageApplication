using GarageApplication.Classes.Baseclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageApplication.Program;

namespace GarageApplication.Classes.Subclass
{
    internal class Boat : Vehicle
    {
        public double Length { get; set; }

        public Boat(string regNum, string color, uint numOfWheels, double length) : base(regNum, color, numOfWheels)
        {
            Length = length;
        }
    }
}

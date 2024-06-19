using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.Classes.Baseclass
{
    public class Vehicle
    {
        //Todo make read-only, porivate
        public string RegNum { get; set; }
        public string Color { get; set; }
        public uint NumOfWheels { get; set; }

        public Vehicle(string regNum = "abc123", string color = "white", uint numOfWheels = 4)
        {
            RegNum = regNum;
            Color = color;
            NumOfWheels = numOfWheels;
        }
    }
}

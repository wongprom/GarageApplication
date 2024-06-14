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
        public int NumOfWheels { get; set; }

        //Todo random regnum generator
        //Todo have 5 colors, random pick color
        public Vehicle(string regNum = "abc123", string color = "white", int numOfWheels = 4)
        {
            RegNum = regNum;
            Color = color;
            NumOfWheels = numOfWheels;
        }
    }
}

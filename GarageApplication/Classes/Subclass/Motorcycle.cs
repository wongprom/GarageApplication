using GarageApplication.Classes.Baseclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageApplication.Program;

namespace GarageApplication.Classes.Subclass
{
    internal class Motorcycle : Vehicle
    {
        public uint CylinderVolume { get; set; }
        public Motorcycle(string regNum, string color, uint numOfWheels, uint cylinderVolume) : base(regNum, color, numOfWheels)
        {
            CylinderVolume = cylinderVolume;
        }
    }
}

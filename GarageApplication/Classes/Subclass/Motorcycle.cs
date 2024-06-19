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
        public int CylinderVolume { get; set; }
        public Motorcycle(string regNum, string color, uint numOfWheels, int cylinderVolume) : base(regNum, color, numOfWheels)
        {
            CylinderVolume = cylinderVolume;
        }
    }
}

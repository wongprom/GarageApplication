using GarageApplication.Classes.Baseclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageApplication.Program;

namespace GarageApplication.Classes.Subclass
{
    internal class Airplane : Vehicle
    {
        public int NumOfEngines { get; set; }
        public Airplane(string regNum, string color, uint numOfWheels, int numOfEngines) : base(regNum, color, numOfWheels)
        {
            NumOfEngines = numOfEngines;
        }
    }
}

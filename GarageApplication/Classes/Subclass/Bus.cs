﻿using GarageApplication.Classes.Baseclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageApplication.Program;

namespace GarageApplication.Classes.Subclass
{
    internal class Bus : Vehicle
    {
        public uint NumOfSeats { get; set; }

        public Bus(string regNum, string color, uint numOfWheels, uint numOfSeats) : base(regNum, color, numOfWheels)
        {
            NumOfSeats = numOfSeats;
        }
    }
}

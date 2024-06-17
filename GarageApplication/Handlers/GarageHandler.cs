using GarageApplication.Classes.Baseclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.Handlers
{
    internal class GarageHandler
    {
        private Garage<Vehicle> _garage;

        public GarageHandler(int numOfLotsInput)
        {
            _garage = new Garage<Vehicle>(numOfLotsInput);
        }

        public bool ParkVehicle(Vehicle vehicle)
        {
            return _garage.Park(vehicle);
        }
        public bool RemoveVehicle(string regNum)
        {
            return _garage.Remove(regNum);
        }
    }
}

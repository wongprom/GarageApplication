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

        public IEnumerable<Vehicle> ListVehicles()
        { 
            return _garage;
        }

        public Dictionary<string, int> ListVehicleType()
        {
            Dictionary<string, int> vehicleTypes = new Dictionary<string, int>();

            foreach (Vehicle vehicle in _garage)
            {
                var vehicleType = vehicle.GetType().Name;
                if (vehicleTypes.ContainsKey(vehicleType))
                {
                    vehicleTypes[vehicleType]++;
                }
                else
                {
                    vehicleTypes[vehicleType] = 1;
                }
            }
            return vehicleTypes;
        }

        public Vehicle? GetVehicleByRegNum(string regNum) 
        {
            return _garage.GetVehicleByRegNum(regNum);
        }

    }
}

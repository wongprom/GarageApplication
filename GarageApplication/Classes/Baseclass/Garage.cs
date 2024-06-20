using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("GarageApplication.Test")]

namespace GarageApplication.Classes.Baseclass
{
    internal class Garage<T> : IEnumerable<T>  where T : Vehicle
    {
        private T?[] _vehicles;
        public int NumOfParkingLots { get; private set; }

        public Garage(uint numOfParkingLots)
        {
            _vehicles = new T[numOfParkingLots];
            OnGarageCreated(numOfParkingLots);
            NumOfParkingLots = (int)numOfParkingLots;
        }

        protected void OnGarageCreated(uint numOfParkingLots)
        {
            //Console.Clear();
            Console.WriteLine($"You now have a garage with {numOfParkingLots} lots!");
        }

        public bool Park(T vehicle)
        {
            if (NumOfParkingLots >= _vehicles.Length)
            {
                return false; // garage is full
            }
            _vehicles[NumOfParkingLots++] = vehicle;
            return true; // Vehicle Parked
        }

        public bool Remove(string regNum) 
        {
            for (int i = 0; i < NumOfParkingLots; i++)
            {
                if (_vehicles?[i]!.RegNum == regNum)
                {
                    _vehicles[i] = _vehicles[--NumOfParkingLots];
                    _vehicles[NumOfParkingLots] = null;
                    return true;
                }
            }
            return false;
        }

        public Vehicle? GetVehicleByRegNum(string regNum)
        {
            foreach (var vehicle in _vehicles)
            {
                if(vehicle?.RegNum?.ToLower() == regNum.ToLower())
                {
                    return vehicle;
                }
            }
            return null;
        }
       

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in _vehicles)
            {
                if(vehicle != null)
                {
                    yield return vehicle;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

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
        private int _currentParkedVehicles;
        private int _numOfParkingLots;

        public Garage(uint numOfParkingLots)
        {
            _vehicles = new T[numOfParkingLots];
            _numOfParkingLots = (int)numOfParkingLots;
            OnGarageCreated(numOfParkingLots);
        }
        public int NumberOfParkingLots => _numOfParkingLots;
        public bool GarageIsFull => _currentParkedVehicles >= NumberOfParkingLots;

        protected void OnGarageCreated(uint numOfParkingLots)
        {
            //Console.Clear();
            Console.WriteLine($"You now have a garage with {numOfParkingLots} lots!");
        }

        public bool Park(T vehicle)
        {
            if(GarageIsFull) return false;

            int firstEmpty = System.Array.IndexOf(_vehicles, null);
            _vehicles[firstEmpty] = vehicle;
            _currentParkedVehicles++;
            return true; // Vehicle Parked
        }

        public bool Remove(string regNum) 
        {
            for (int i = 0; i < _numOfParkingLots; i++)
            {
                if (_vehicles?[i]!.RegNum == regNum)
                {
                    _vehicles[i] = default(T);
                    _currentParkedVehicles--;
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

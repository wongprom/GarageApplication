﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.Classes.Baseclass
{
    internal class Garage<T> : IEnumerable<T>  where T : Vehicle
    {
        private T?[] _vehicles;
        public int NumOfParkingLots { get; set; }

        public Garage(int numOfParkingLots)
        {
            if (numOfParkingLots < 1)
            {
                throw new ArgumentException("Number of parking lots must be at least 1");
            }
            _vehicles = new T[numOfParkingLots];
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.Classes.Baseclass
{
    internal class Garage<T> where T : Vehicle
    {
        private T[] _vehicles;
        public int NumOfParkingLots { get; set; }

        public Garage(int numOfParkingLots)
        {
            if (numOfParkingLots < 1)
            {
                throw new ArgumentException("Number of parking lots must be at least 1");
            }
            _vehicles = new T[numOfParkingLots];
            Console.WriteLine($"Yoy now have a garage with {numOfParkingLots} lots!");
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
                if (_vehicles[i].RegNum == regNum)
                {
                    // Vehicle found
                    Console.WriteLine("Found it, need to remove");
                    return true;
                }
            }
            return false;
        }
    }
}

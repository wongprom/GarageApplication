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
    }
}

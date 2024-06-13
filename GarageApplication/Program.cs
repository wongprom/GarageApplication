namespace GarageApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isContinue = true;
            while (isContinue)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3, 0) of your choice"
                        + "\n1. Park Vehicle"
                        + "\n2. Get Vehicle"
                        + "\n3. Info about all Vehicles"
                        + "\n0. Exit the application");
                char input = ' ';
                try
                {
                    input = Console.ReadLine()![0];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter some input!");
                    Console.ResetColor();
                }
                switch (input)
                {
                    case '1':
                        Console.Clear();
                        var parkVehicle = new ParkVehicle();
                        parkVehicle.InitParking();
                        
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("User wants to Get parked vehicle");
                        //ExamineQueue();
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("User wants to Get Info about Vehicles");
                        //ExamineStack();
                        break;
                    case '0':
                        Console.Clear();
                        Console.WriteLine("User Exit Garage Application");
                        isContinue = false;
                        //Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3)");
                        Console.ResetColor();
                        break;
                }
            }
        }


        public class ParkVehicle()
        {
            public void InitParking()
            {
                Console.WriteLine("How many lots do you want in your garage?");
                int numofLotsInput = int.Parse(Console.ReadLine()!);
                var garage = new Garage<Vehicle>(numofLotsInput);
                // Ask user what type of vehicle to park
                // Ask for all info ike regnum, color, numOfWheels

            }
        }
        internal class Garage<T> where T : Vehicle
        {
            private T[] _vehicles;
            public int NumOfParkingLots { get; set; }

            public Garage(int numOfParkingLots)
            {

                if(numOfParkingLots < 1)
                {
                    throw new ArgumentException("Number of parking lots must be at least 1");
                }
                _vehicles = new T[numOfParkingLots];
                Console.WriteLine($"Yoy now have a garage with {numOfParkingLots} lots!");
            }

        }

        #region class, subclass Vehicle
        public class Vehicle
        {
            //Todo make read-only, porivate
            public string RegNum { get; set; } 
            public string Color { get; set; } 
            public int NumOfWheels { get; set; } 
            
            //Todo random regnum generator
            //Todo have 5 colors, random pick color
            public Vehicle(string regNum = "abc123", string color="white", int numOfWheels = 4)
            {
                RegNum = regNum;
                Color = color;
                NumOfWheels = numOfWheels;
            }
        }

        public class Airplane : Vehicle
        {
            public int NumOfEngines { get; set; }
            public Airplane(string regNum, string color, int numOfWheels, int numOfEngines) : base(regNum, color, numOfWheels)  
            {
                NumOfEngines = numOfEngines;
            } 
        } 

        public class Motorcycl : Vehicle
        {
            public int CylinderVolume { get; set; }
            public Motorcycl(string regNum, string color, int numOfWheels, int cylinderVolume) : base(regNum, color, numOfWheels)  
            {
                CylinderVolume = cylinderVolume;
            } 
        }

        public class Car : Vehicle
        {

            public enum FuelType { Gasoline, Diesel }
            public FuelType Fuel { get; set; }

            public Car(string regNum, string color, int numOfWheels, FuelType fuel) : base(regNum, color, numOfWheels)
            {
                Fuel = fuel;
            }
        }

        public class Bus : Vehicle 
        { 
            public int NumOfSeats { get; set; }

            public Bus(string regNum, string color, int numOfWheels, int numOfSeats) : base(regNum, color, numOfWheels)
            {
                NumOfSeats = numOfSeats;
            }
        }

        public class Boat : Vehicle
        {
            public double Length { get; set; }

            public Boat(string regNum, string color, int numOfWheels, double length) : base(regNum, color, numOfWheels)
            {
                Length = length;
            }
        }
        #endregion
    }
}

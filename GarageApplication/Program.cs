using GarageApplication.Classes.Baseclass;
using GarageApplication.Classes.Subclass;
using GarageApplication.Handlers;
using System.Numerics;
using static GarageApplication.Classes.Subclass.Car;

namespace GarageApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many lots do you want in your garage?");
            int numofLotsInput = int.Parse(Console.ReadLine()!);

            var garageHandler = new GarageHandler(numofLotsInput);

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
                        ParkVehicle(garageHandler);
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("User wants to Get parked vehicle");
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("User wants to Get Info about Vehicles");
                        break;
                    case '0':
                        Console.Clear();
                        Console.WriteLine("User Exit Garage Application");
                        isContinue = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3)");
                        Console.ResetColor();
                        break;
                }
            }
        }


        static void ParkVehicle(GarageHandler garageHandler)
        {
            Console.WriteLine("What type of vehacle do you want to park?  \n(1, 2, 3, 0) of your choice"
                       + "\n1. Car"
                       + "\n2. Motorcycle"
                       + "\n3. Airplane"
                       + "\n4. Bus"
                       + "\n5. Boat");
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

            // Todo Validate input regNumber
            Console.Write("Enter registration number, ex abc123: ");
            string regNumber = Console.ReadLine()!;
            
            Console.Write("Enter color: ");
            string color = Console.ReadLine()!;
            
            Console.Write("Enter number of wheels: ");
            int numOfWheels = int.Parse(Console.ReadLine()!);

            Vehicle vehicle = new Vehicle();

            

            switch (input)
            {
                case '1':
                    Console.WriteLine("Enter type of fuel for your car: "
                      + "\n1. Gasoline"
                      + "\n2. Diesel");
                    string fuel = Console.ReadLine()!;
                    //Todo validate input, only 1 or 2 as ligit value
                    FuelType fuelType = (FuelType)Convert.ToInt32(fuel);
                    Console.WriteLine(fuelType);
                    vehicle = new Car(regNumber, color, numOfWheels, fuelType);
                    break;
                case '2':
                    //Todo validate input, only numbers
                    Console.WriteLine("Enter cylinder Volume: ");
                    int cylinderVolume = int.Parse(Console.ReadLine()!);
                    vehicle = new Motorcycle(regNumber, color, numOfWheels, cylinderVolume);
                    break;
                case '3':
                    //Todo validate input, only numbers
                    Console.WriteLine("Enter number of engines: ");
                    int numOfEngines = int.Parse(Console.ReadLine()!);
                    vehicle = new Airplane(regNumber, color, numOfWheels, numOfEngines);
                    break;
                case '4':
                    //Todo validate input, only numbers
                    Console.WriteLine("Enter number of seats: ");
                    int numOfSeats = int.Parse(Console.ReadLine()!);
                    vehicle = new Bus(regNumber, color, numOfWheels, numOfSeats);
                    break; 
                case '5':
                   
                  
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter some valid input (0, 1, 2, 3)");
                    Console.ResetColor();
                    break;
            }
            Console.WriteLine($"garageHandler: {garageHandler}");
            Console.WriteLine($"vehicle: {vehicle.RegNum}");
        }
       
    }
}

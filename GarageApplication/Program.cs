using GarageApplication.Classes.Baseclass;
using GarageApplication.Classes.Subclass;
using GarageApplication.Handlers;
using System.Drawing;
using System.Numerics;
using System.Security.Cryptography;
using static GarageApplication.Classes.Subclass.Car;

namespace GarageApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many lots do you want in your garage? (Minimum 4 lots): ");
            int numofLotsInput = int.Parse(Console.ReadLine()!);

            var garageHandler = new GarageHandler(numofLotsInput);

            bool isContinue = true;
            while (isContinue)
            {
                Console.WriteLine("Please navigate through the menu by entering the number (1, 2, 3, 4, 0) of your choice"
                        + "\n1. Park Vehicle"
                        + "\n2. Remove Vehicle"
                        + "\n3. Info Vehicles"
                        + "\n4. List Vehicles Type"
                        + "\n5. Get vehicle by register number"
                        + "\n6. init Populate garage with 2 Cars, 1 Motorcycle, 1 Boat. WARNING! Will replace existing vehicles"
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
                        RemoveVehicle(garageHandler);
                        break;
                    case '3':
                        Console.Clear();
                        ListVehicles(garageHandler);
                        break;
                    case '4':
                        Console.Clear();
                        ListVehiclesType(garageHandler);
                        break;
                    case '5':
                        Console.Clear();
                        GetVehicleByRegNum(garageHandler);
                        break;
                    case '6':
                        Console.Clear();
                        List<Vehicle> inintVehicles = new List<Vehicle>
                        {
                            new Car(regNum:"car001", color:"Red", numOfWheels:4, FuelType.Gasoline),
                            new Car(regNum:"car002", color:"Green", numOfWheels:4, FuelType.Diesel),
                            new Motorcycle(regNum:"mot001", color:"Black", numOfWheels:2, 250),
                            new Boat(regNum:"boa001", color:"Green", numOfWheels:0, 190),
                        };
                        foreach (Vehicle vehicle in inintVehicles)
                        {
                            //Todo make sure that garage is not full when case 6 used several times
                            garageHandler.ParkVehicle(vehicle);
                        }
                        ListVehicles(garageHandler);
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
            bool noVehicle = true;
            char inputVehicle = ' ';
            while (noVehicle)
            {
                Console.WriteLine("What type of vehicle do you want to park?"
                           + "\n1. Car"
                           + "\n2. Motorcycle"
                           + "\n3. Airplane"
                           + "\n4. Bus"
                           + "\n5. Boat");
                
                inputVehicle = Console.ReadLine()![0];
                int convertInputVehicle = inputVehicle - '0';

                if (convertInputVehicle > 0 && convertInputVehicle < 6)
                {
                    noVehicle = false;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter valid input!");
                    Console.ResetColor();
                }
                
                
            }

            // Todo Validate input regNumber
            Console.Write("Enter registration number, ex abc123: ");
            string regNumber = Console.ReadLine()!;
            
            Console.Write("Enter color: ");
            string color = Console.ReadLine()!;
            
            Console.Write("Enter number of wheels: ");
            int numOfWheels = int.Parse(Console.ReadLine()!);

            Vehicle vehicle = new Vehicle();

            

            switch (inputVehicle)
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
                    //Todo validate input, only numbers
                    Console.WriteLine("Enter boat length: ");
                    int length = int.Parse(Console.ReadLine()!);
                    vehicle = new Boat(regNumber, color, numOfWheels, length);

                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter some valid input (0, 1, 2, 3)");
                    Console.ResetColor();
                    break;
            }

            if (garageHandler.ParkVehicle(vehicle))
            {
                Console.WriteLine("Vehicle parked");
            }
            else
            {
                Console.WriteLine("Garage full!");
            }
        }
       
        static void RemoveVehicle(GarageHandler garageHandler)
        {
            Console.Write("Enter register number on vehicle to remove: ");
            string regNum = Console.ReadLine()!;

            if(garageHandler.RemoveVehicle(regNum))
            {
                Console.WriteLine("Vehicle removed");
            }
            else
            {
                Console.WriteLine("Vehicle not found");
            }
        }

        static void ListVehicles(GarageHandler garageHandler)
        {
            Console.WriteLine("Vehicles in garage: ");
            foreach (var vehicle in garageHandler.ListVehicles())
            {
                Console.WriteLine($"{vehicle.GetType().Name} - {vehicle.RegNum}");
            }
            Console.WriteLine();
        }

        static void ListVehiclesType(GarageHandler garageHandler)
        {
            Console.Clear();
            Console.WriteLine("Vehicles Type and count in garage: ");
            foreach (var vehicle in garageHandler.ListVehicleType())
            {
                Console.WriteLine($"Type: {vehicle.Key} - Count: {vehicle.Value}");
            }
            Console.WriteLine();
        }
        static void GetVehicleByRegNum(GarageHandler garageHandler)
        {
            Console.Write("Enter register number on vehicle to get: ");
            string regNum = Console.ReadLine()!;

            var vehicle = garageHandler.GetVehicleByRegNum(regNum);

            if(vehicle != null)
            {
                Console.WriteLine($"{vehicle.GetType().Name} - {vehicle.RegNum}");
            }
            else
            {
                Console.WriteLine("Vehicle not found");
            }

        }
    }
}

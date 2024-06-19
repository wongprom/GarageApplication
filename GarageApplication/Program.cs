using GarageApplication.Classes.Baseclass;
using GarageApplication.Classes.Subclass;
using GarageApplication.Handlers;
using GarageApplication.GarageApplication.Helpers;
using System.Text;
using static GarageApplication.Classes.Subclass.Car;

namespace GarageApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint numOfLotsInput = new int();
            bool isValidInput = false;
            while (!isValidInput) 
            {
                string prompt = "How many lots do you want in your garage? (Minimum 4 lots): ";
                numOfLotsInput = Util.AskForUInt(prompt);

                if (numOfLotsInput >= 4)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Number of parking lots must be at least 4. Please enter a valid number.");
                    Console.ResetColor();
                }
            }

            var garageHandler = new GarageHandler(numOfLotsInput);

            bool isContinue = true;
            while (isContinue)
            {
                Console.WriteLine("Please navigate through the menu by entering the number (0 - 6) of your choice"
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
                            new Car(regNum:Util.GenerateRandomRegNum(), color:"Red", numOfWheels:4, FuelType.Gasoline),
                            new Car(regNum:Util.GenerateRandomRegNum(), color:"Green", numOfWheels:4, FuelType.Diesel),
                            new Motorcycle(regNum:Util.GenerateRandomRegNum(), color:"Black", numOfWheels:2, 250),
                            new Boat(regNum:Util.GenerateRandomRegNum(), color:"Green", numOfWheels:0, 190),
                        };
                        foreach (Vehicle vehicle in inintVehicles)
                        {
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
                        Console.WriteLine("Please valid input (0, 1, 2, 3, 4, 5, 6.)");
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

            string regNumber = Util.AskForRegNum("Enter registration number, ex abc123:");

            string color = Util.AskForLettersOnly("Enter color:");

            uint numOfWheels = Util.AskForUInt("Enter number of wheels:");

            Vehicle vehicle = new Vehicle();

            switch (inputVehicle)
            {
                case '1':
                   string fuel= Util.AskForFuelType("Enter type of fuel for your car: "
                      + "\n1. Gasoline"
                      + "\n2. Diesel");
                    FuelType fuelType = (FuelType)Convert.ToInt32(fuel);
                    Console.WriteLine($"You choose {fuelType} as fuel type.");
                    vehicle = new Car(regNumber, color, numOfWheels, fuelType);
                    break;
                case '2':
                    uint cylinderVolume = Util.AskForUInt("Enter cylinder Volume:");
                    Console.WriteLine($"Your cylinder volum is {cylinderVolume}.");
                    vehicle = new Motorcycle(regNumber, color, numOfWheels, cylinderVolume);
                    break;
                case '3':
                    uint numOfEngines = Util.AskForUInt("Enter number of engines:");
                    Console.WriteLine($"Number of engines: {numOfEngines}");
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

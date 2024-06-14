using GarageApplication.Classes.Baseclass;
using GarageApplication.Classes.Subclass;
using GarageApplication.Handlers;

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
            Console.WriteLine($"garageHandler: {garageHandler}");
        }
       
    }
}

using GarageApplication.Classes.Baseclass;
using GarageApplication.Classes.Subclass;

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


        public class ParkVehicle()
        {
            public void InitParking()
            {
                Console.WriteLine("How many lots do you want in your garage?");
                int numofLotsInput = int.Parse(Console.ReadLine()!);
                var garage = new Garage<Vehicle>(numofLotsInput);
                Vehicle vehicle = new Vehicle("wer234", "white", 4);
                Car car = new Car("wer234", "white", 4, Car.FuelType.Gasoline);
                Boat boat = new Boat("wer234", "white", 4, 5);
                Airplane airplane = new Airplane("wer234", "white", 4, 2);
                Motorcycle motorcycle = new Motorcycle("wer234", "white", 2, 250);

                // Ask user what type of vehicle to park
                // Ask for all info ike regnum, color, numOfWheels
            }
        }
       
    }
}

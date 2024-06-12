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
                        Console.WriteLine("User wants to PARK");
                        //ExamineList();
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
    }
}

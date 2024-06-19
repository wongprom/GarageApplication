using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.GarageApplication.Helpers
{
    public class Util
    {
        public static string GenerateRandomRegNum()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";

            StringBuilder regNum = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 3; i++)
            {
                regNum.Append(chars[random.Next(chars.Length)]);
            }

            for (int i = 0; i < 3; i++)
            {
                regNum.Append(digits[random.Next(digits.Length)]);
            }

            return regNum.ToString();
        }

        public static string AskForString(string prompt)
        {
            bool success = false;
            string answer;

            do
            {
                Console.Write($"{prompt} ");
                answer = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(answer))
                {
                    Console.WriteLine($"Your input is not valid.");
                }
                else
                {
                    success = true;
                }


            } while (!success);

            return answer;
        }

        public static uint AskForUInt(string prompt)
        {
            do
            {
                string input = AskForString(prompt);

                if (uint.TryParse(input, out uint result))
                {
                    return result;
                }

            } while (true);
        }
    }
}

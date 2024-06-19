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

        public static string AskForLettersOnly(string prompt)
        {
            string answer;

            do
            {
                answer = AskForString(prompt);

                if (answer.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid input: Color cannot contain numbers.");
                }
                else
                {
                    break;
                }

            } while (true);

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

        public static string AskForRegNum(string prompt)
        { 
            string answer;

            while (true) 
            {
                answer = AskForString(prompt);

                if(answer.Length != 6)
                {
                    Console.WriteLine("Invalid input: Registration number must be exactly 6 characters long.");
                    continue;
;               }

                string letters = answer.Substring(0, 3);
                string digits = answer.Substring(3);

                if (!letters.All(char.IsLetter))
                {
                    Console.WriteLine("Invalid input: First 3 characters must be letters.");
                    continue;
                }

                
                if (!digits.All(char.IsDigit))
                {
                    Console.WriteLine("Invalid input: Last 3 characters must be digits.");
                    continue;
                }
                return answer;

            }

        }

        public static string AskForFuelType(string prompt)
        {
            string answer;

            while (true)
            {
                answer = AskForString(prompt);

                if (answer != "1" && answer != "2")
                {
                    Console.WriteLine("Invalid input, choose 1 or 2.");
                    continue;
                }
                else
                {
                    Console.WriteLine();
                    return answer.ToString();
                }
            }

        }
    }
}

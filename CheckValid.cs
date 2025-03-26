using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class CheckValid
    {
        public static CarType CheckValidType()
        {
            while (true)
            {
                try
                {
                    string? input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        throw new ArgumentException("This field cannot be empty. Please enter a valid value");
                    }
                    if (Enum.TryParse(input, out CarType carType) && Enum.IsDefined(typeof(CarType), carType))
                    {
                        return carType;
                    }
                    throw new ArgumentException("Invalid Type. Please enter 0 (Electric) or 1 (Fuel).");
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static int CheckValidYear()
        {
            while (true)
            {
                try
                {
                    string? input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        throw new ArgumentException("This field cannot be empty. Please enter a valid value");
                    }

                    if (int.TryParse(input, out int year) && year >= 1886 && year <= DateTime.Now.Year + 1)
                    {
                        return year;
                    }
                    throw new ArgumentException("Invalid Year. Please enter a number between 1886 and next year.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        public static string CheckNonEmptyInput(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine()?.Trim()!;

                    if (string.IsNullOrEmpty(input))
                        throw new ArgumentException("This field cannot be empty. Please enter a valid value.");

                    return input;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}

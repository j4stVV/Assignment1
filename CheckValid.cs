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
                if (Enum.TryParse(Console.ReadLine(), out CarType carType) && Enum.IsDefined(typeof(CarType), carType))
                {
                    return carType;
                }
                Console.WriteLine("Invalid Type");
            }
        }
        public static int CheckValidYear()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int year) && year > 0)
                {
                    return year;
                }
                Console.WriteLine("Invalid Year");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW28._11._22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // task 1

            //int number = int.Parse(Console.ReadLine());
            //while (number < 0 || number > 100)
            //{
            //    Console.WriteLine("Error input, try again!");
            //    number = int.Parse(Console.ReadLine());
            //}
            //if (number % 3 == 0 && number % 5 == 0) Console.WriteLine("Fizz Buzz");
            //else if (number % 3 == 0) Console.WriteLine("Fizz");
            //else if (number % 5 == 0) Console.WriteLine("Buzz");
            //else Console.WriteLine(number);

            // task 2

            //float a = float.Parse(Console.ReadLine());
            //float b = float.Parse(Console.ReadLine());
            //Console.WriteLine(a * (b / 100));

            // task 3

            //int result = 0;
            //int input;
            //for (int i = 0, k = 1000; i < 4; i++, k /= 10)
            //{
            //    input = int.Parse(Console.ReadLine());
            //    result += input * k;
            //}
            //Console.WriteLine(result);

            // task 4

            //string str = Console.ReadLine();
            //while (str.Length != 6)
            //{
            //    Console.WriteLine("Error input, try again!");
            //    str = Console.ReadLine();
            //}
            //char[] chars = str.ToCharArray();
            //int first = int.Parse(Console.ReadLine());
            //int second = int.Parse(Console.ReadLine());
            //chars[first - 1] = str[second - 1];
            //chars[second - 1] = str[first - 1];
            //Console.WriteLine(chars);

            // task 5

            //DateTime date = DateTime.Parse(Console.ReadLine());
            //if (date.Month == 3 | date.Month == 4 | date.Month == 5) Console.Write("Spring ");
            //else if (date.Month == 6 | date.Month == 7 | date.Month == 8) Console.Write("Summer ");
            //else if (date.Month == 9 | date.Month == 10 | date.Month == 11) Console.Write("Autumn ");
            //else Console.Write("Winter ");
            //Console.WriteLine(date.DayOfWeek);

            // task 6

            //Console.Write("Input temperature: ");
            //float temp = float.Parse(Console.ReadLine());
            //Console.Write("Input 1 - convert to celsius, 2 - convert to fahrenheit: ");
            //if (int.Parse(Console.ReadLine()) == 1) Console.WriteLine((temp - 32) * 5 / 9 + " °С");
            //else Console.WriteLine((temp * 9 / 5) + 32 + " °F");

            // task 7

            int min = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            if (min > max)
            {
                max = max + min;
                min = max - min;
                max = max - min;
            }
            Console.WriteLine(min +" "+ max);
            if (min % 2 != 0) min++;
            for (int i = min; i <= max; i+=2)
            {
                Console.WriteLine(i);
            }                       


            Console.ReadLine();
        }
    }
}

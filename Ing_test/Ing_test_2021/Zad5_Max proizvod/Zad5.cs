using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad5_Max_proizvod
{
    public class Test
    {
        public static void Main()
        {
            var inputString = Console.ReadLine();
            var inputNumbers = inputString.Split(',');
            int[] numbers = new int[inputNumbers.Length];
            for (int i = 0; i < inputNumbers.Length; i++)
            {
                numbers[i] = int.Parse(inputNumbers[i]);
            }

            // your code goes here
            // print your results to the console using:
            // Console.WriteLine(“your result here”);
        }
    }

}

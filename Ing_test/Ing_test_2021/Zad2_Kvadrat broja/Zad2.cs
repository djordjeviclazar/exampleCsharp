using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2_Kvadrat_broja
{
    public class Test
    {
        public static void Main()
        {
            var inputString = Console.ReadLine();
            var number = int.Parse(inputString); // 1-4 digits

            int currentVal = number, result = number == 0 ? 9 : 0, currentDigit, multiplier = 1, square, iteration = 0;
            while(currentVal != 0)
            {
                currentDigit = currentVal % 10;

                square = currentDigit == 0 ? 9 : (currentDigit * currentDigit);
                // counting digits for square
                int newMultiplier = multiplier;
                {
                    int pom = square;
                    while(pom != 0)
                    {
                        pom = pom / 10;
                        newMultiplier = newMultiplier * 10;
                    }
                }

                result = result + ((multiplier * square));

                currentVal = currentVal / 10;
                multiplier = newMultiplier;
                iteration++;
            }

            // sign:
            if (number < 0) { result = -result; }

            // print your results to the console using:
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }

}

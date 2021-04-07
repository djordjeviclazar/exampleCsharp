using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad3_Anin_dnevnik
{
    public class Test
    {
        public static void Main()
        {
            var inputString = Console.ReadLine();
            var inputNumbers = inputString.Split(',');
            var firstNumber = int.Parse(inputNumbers[0]);
            var secondNumber = int.Parse(inputNumbers[1]);

            // 3 digit numbers
            int divNum = 1, result = 0, currentFirst, currentSecond, pom;
            for (int i = 0; i < 3; i++)
            {
                currentFirst = (firstNumber / divNum) % 10;
                currentSecond = (secondNumber / divNum) % 10;

                pom = Math.Abs(currentFirst - currentSecond);

                if (pom > 5)
                {
                    pom = 10 - pom;
                }

                result = result + pom;
                divNum = divNum * 10;
            }

            // your code goes here
            // print your results to the console using:
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }

}

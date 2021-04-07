using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad5_Max_proizvod
{
    public class Test
    {
        /*
         * Score: 3/5
         */

        public static void Main()
        {
            var inputString = Console.ReadLine();
            var inputNumbers = inputString.Split(',');
            int[] numbers = new int[inputNumbers.Length];
            for (int i = 0; i < inputNumbers.Length; i++)
            {
                numbers[i] = int.Parse(inputNumbers[i]);
            }

            int maxMul = numbers[0], currentMul = 1, nextMul; // brojevi -10-10
            for (int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] == 0)
                {
                    if (maxMul < 0) 
                    { 
                        maxMul = 0;
                        
                        
                    }
                    currentMul = 1;
                    continue;
                }
                nextMul = currentMul * numbers[i];

                if(nextMul < currentMul)
                {
                    if(currentMul > maxMul) { maxMul = currentMul; }

                    currentMul = numbers[i];
                }
                else
                {
                    currentMul = nextMul;
                    if(currentMul > maxMul) { maxMul = currentMul; }
                }
            }

            // print your results to the console using:
            Console.WriteLine(maxMul);
            Console.ReadLine();
        }
    }

}

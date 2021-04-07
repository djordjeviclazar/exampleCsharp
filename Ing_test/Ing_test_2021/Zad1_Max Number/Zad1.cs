using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1_Max_Number
{
    public class Test
    {
        /*
         * Score: 3/5
         */

        public static void Main()
        {
            var inputString = Console.ReadLine();
            var number = int.Parse(inputString);

            // count occurences:
            int[] occurences = new int[10]; // for each digit
            for (int i = 0; i < 10; i++)
            {
                occurences[i] = 0;
            }

            int pom = Math.Abs(number);
            int digit;
            int[] digits = new int[inputString.Length];// 0 - less significant digit
            int index = 0;
            while (pom != 0)
            {
                digit = pom % 10;
                occurences[digit]++;
                digits[index++] = digit;
                pom = pom / 10;
            }

            // find digits for replacement:
            bool foundReplacement = false;
            int replacement = 0, place = 0;
            for(int i = digits.Length - 1; i >= 0 && !foundReplacement; i--)
            {
                if(number > 0)
                {
                    for(int k = 9; k >= digits[i] && !foundReplacement; k--)
                    {
                        if (k > digits[i] && occurences[k] > 0)
                        {
                            foundReplacement = true;
                            place = i;
                            replacement = k;
                        }
                        else
                        {
                            occurences[k]--;
                        }
                    }
                    
                }
                else
                {
                    for (int k = 0; k <= digits[i] && !foundReplacement; k++)
                    {
                        if (k < digits[i] && occurences[k] > 0)
                        {
                            foundReplacement = true;
                            place = i;
                            replacement = k;
                        }
                        else
                        {
                            occurences[k]--;
                        }
                    }
                }
            }

            // find digit to be placed as more significant and create new number:
            int secondPlace = 0;
            if (foundReplacement)
            {
                for(int i = 0; i < digits.Length; i++)
                {
                    if(digits[i] == replacement)
                    {
                        if (occurences[replacement] == 1)
                        {
                            secondPlace = i;
                            break;
                        }
                        else
                        {
                            occurences[replacement]--;
                        }
                    }
                }
            }

            int t = digits[secondPlace];
            digits[secondPlace] = digits[place];
            digits[place] = t;

            int result = 0, multiplicator = 1;
            for(int i = 0; i < digits.Length; i++)
            {
                result = result + (digits[i] * multiplicator);
                multiplicator = multiplicator * 10;
            }

            if (number < 0) { result = -result; }

            // print your results to the console using:
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }

}

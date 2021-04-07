using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad4_Anagrami
{
    public class Test
    {
        /*
         * Score:4/5
         */

        public static bool IsAnagram(string wordA, string wordB)
        {
            bool isAnagram = true;

            if(wordA.Length != wordB.Length) { return false; }

            string a = wordA.ToLower(), b = wordB.ToLower();
            int[] occurencesA = new int[25];
            for(int i = 0; i < 25; i++)
            {
                occurencesA[i] = 0;
            }

            byte[] aBytes = Encoding.ASCII.GetBytes(a), bBytes = Encoding.ASCII.GetBytes(b);
            byte[] pomB = Encoding.ASCII.GetBytes("a");
            for(int i = 0; i < aBytes.Length; i++)
            {
                occurencesA[aBytes[i] - pomB[0]]++;
            }

            for(int i = 0; i < bBytes.Length; i++)
            {
                int pom = occurencesA[bBytes[i] - pomB[0]];

                if(pom == 0) { return false; }
                occurencesA[bBytes[i] - pomB[0]]--;
            }

            // last check, all 0:
            for(int i = 0; i < occurencesA.Length; i++)
            {
                if(occurencesA[i] != 0) { return false; }
            }

            return isAnagram;
        }

        public static void Main()
        {
            var inputString = Console.ReadLine();
            inputString.TrimEnd('.');
            string[] words = inputString.Split(' ');

            int count = 0;
            for(int i = 0; i < words.Length; i++)
            {
                for(int k = i + 1; k < words.Length; k++)
                {
                    if (k == i) { continue; }

                    count += IsAnagram(words[i], words[k]) ? 1 : 0;
                }
            }

            // print your results to the console using:
            Console.WriteLine(count);
            Console.ReadLine();
        }
    }

}

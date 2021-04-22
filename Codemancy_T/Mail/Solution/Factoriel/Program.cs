using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Factoriel
{
    class Program
    {
        public static BigInteger Factoriel(BigInteger number)
        {
            if(number < 0) { return -1; }
            if(number == 0 || number == 1) { return 1; }

            BigInteger mul = number--;
            BigInteger compare = 1;
            while(number > BigInteger.One)
            {
                mul = mul * number;
                number--;
            }

            return mul;
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(Factoriel(100000));
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(Factoriel(i));
            }
            Console.ReadLine();
        }
    }
}

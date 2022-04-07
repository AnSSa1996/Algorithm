using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] humans = new int[6] { 1, 2, 3, 3, 4, 10 };
            int[] evils = new int[7] { 1, 2, 2, 2, 3, 5, 10 };

            int N = int.Parse(sr.ReadLine());

            for (int i = 1; i <= N; i++)
            {
                int[] gan = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int[] sau = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                int ganScore = 0;
                int sauScore = 0;
                for (int j = 0; j < gan.Length; j++) ganScore += humans[j] * gan[j];
                for (int j = 0; j < sau.Length; j++) sauScore += evils[j] * sau[j];

                if (ganScore > sauScore) sw.WriteLine($"Battle {i}: Good triumphs over Evil");
                else if (ganScore < sauScore) sw.WriteLine($"Battle {i}: Evil eradicates all trace of Good");
                else sw.WriteLine($"Battle {i}: No victor on this battle field");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
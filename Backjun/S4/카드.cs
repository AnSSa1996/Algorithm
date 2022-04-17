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

            Dictionary<long, long> dict = new Dictionary<long, long>();

            long N = long.Parse(sr.ReadLine());

            long max = 0;
            long cardMax = 0;
            for (long i = 0; i < N; i++)
            {
                long card = long.Parse(sr.ReadLine());
                if (dict.ContainsKey(card)) dict[card]++;
                else dict.Add(card, 1);

                if (max < dict[card])
                {
                    max = dict[card];
                    cardMax = card;
                }
                else if (max == dict[card])
                {
                    cardMax = Math.Min(cardMax, card);
                }
            }

            sw.WriteLine(cardMax);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

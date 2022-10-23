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

            long[] inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            long N = inputs[0]; long P = inputs[1]; long Q = inputs[2];

            Dictionary<long, long> Dict = new Dictionary<long, long>();

            long Recursive(long index)
            {
                if (index == 0) return 1;

                long AKey = index / P;
                long AResult = 0;

                if (Dict.ContainsKey(AKey))
                {
                    AResult = Dict[AKey];
                }
                else
                {
                    AResult = Recursive(AKey);
                    Dict.Add(AKey, AResult);
                }

                long BKey = index / Q;
                long BResult = 0;
                if (Dict.ContainsKey(BKey))
                {
                    BResult = Dict[BKey];
                }
                else
                {
                    BResult = Recursive(BKey);
                    Dict.Add(BKey, BResult);
                }

                return AResult + BResult;
            }

            sw.WriteLine(Recursive(N));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

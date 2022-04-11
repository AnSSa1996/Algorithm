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

            while (true)
            {
                int N = int.Parse(sr.ReadLine());
                if (N == -1) break;
                List<int> divLst = new List<int>();
                divLst.Add(1);
                for (int i = 2; i * i <= N; i++)
                {
                    if (N % i == 0)
                    {
                        divLst.Add(i);
                        divLst.Add(N / i);
                    }
                }

                if (divLst.Sum() == N)
                {
                    divLst.Sort();
                    sw.WriteLine($"{N} = {string.Join(" + ", divLst)}");
                }
                else sw.WriteLine($"{N} is NOT perfect.");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
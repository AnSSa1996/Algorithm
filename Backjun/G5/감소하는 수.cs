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

            int N = int.Parse(sr.ReadLine());
            int result = 0;

            List<long> decreaseNumList = new List<long>();

            if (N > 1022)
            {
                sw.WriteLine(-1);
            }
            else
            {
                for (int num = 0; num < 10; num++)
                {
                    SanghunSolution(num);
                }
                decreaseNumList.Sort();
                sw.WriteLine(decreaseNumList[N]);
            }

            void SanghunSolution(long num)
            {
                decreaseNumList.Add(num);
                for (int i = 0; i <= 9; i++)
                {
                    if (num % 10 > i)
                    {
                        SanghunSolution(num * 10 + i);
                    }
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
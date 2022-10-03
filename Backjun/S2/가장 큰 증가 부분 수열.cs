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

            List<int> decreaseNumList = new List<int>();

            if (N > 1022) sw.WriteLine(-1);
            else
            {
                SanghunSolution(N);
            }

            sw.WriteLine(decreaseNumList[N]);

            void SanghunSolution(int num)
            {
                decreaseNumList.Add(num);
                N--;
                if (N == 0) return;

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
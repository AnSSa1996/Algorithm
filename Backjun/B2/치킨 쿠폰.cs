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
                string str = sr.ReadLine();
                if (str == null) break;
                string[] strArray = str.Split();
                int N = int.Parse(strArray[0]);
                int K = int.Parse(strArray[1]);
                int total = N;

                while (true)
                {
                    if (N < K) break;
                    total += N / K;
                    N = N / K + N % K;
                }
                sw.WriteLine(total);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
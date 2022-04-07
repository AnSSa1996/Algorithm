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

            int count = 0;
            int N = int.Parse(sr.ReadLine());
            int temp = N;
            while (true)
            {
                int a = temp / 10;
                int b = temp % 10;
                int c = (a + b) % 10;
                temp = b * 10 + c;

                count++;
                if (temp == N) break;
            }

            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
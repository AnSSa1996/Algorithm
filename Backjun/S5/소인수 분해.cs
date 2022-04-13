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

            int div = 2;

            while (N != 1)
            {
                if (N % div == 0)
                {
                    sw.WriteLine(div);
                    N /= div;
                }
                else
                {
                    div++;
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

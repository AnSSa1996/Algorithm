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

            int num = 665;
            while (N > 0)
            {
                num++;
                if (num.ToString().Contains("666"))
                {
                    N--;
                }
            }

            sw.WriteLine(num);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

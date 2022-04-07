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

            sw.WriteLine("n e");
            sw.WriteLine("- -----------");

            double e = 0;
            for (int i = 0; i < 10; i++)
            {
                int n = i;
                e += 1 / facotrial(i);

                if (e.ToString().Length > 3) sw.WriteLine($"{n} {e:f9}");
                else sw.WriteLine($"{n} {e}");

            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static double facotrial(double num)
        {
            if (num == 0 || num == 1)
                return 1;
            else return facotrial(num - 1) * num;
        }
    }
}
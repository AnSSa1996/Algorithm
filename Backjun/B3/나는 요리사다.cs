using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            int maxNum = 1;
            int maxValue = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).Sum();
            for (int i = 2; i < 6; i++)
            {
                int NextSum = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).Sum();
                if (maxValue < NextSum)
                {
                    maxValue = NextSum;
                    maxNum = i;
                }
            }


            sw.WriteLine($"{maxNum} {maxValue}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

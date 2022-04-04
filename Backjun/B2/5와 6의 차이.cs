using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int left = inputs[0];
            int right = inputs[1];

            string fiveLeft = left.ToString().Replace('6', '5');
            string fiveRight = right.ToString().Replace('6', '5');

            string sixLeft = left.ToString().Replace('5', '6');
            string sixRight = right.ToString().Replace('5', '6');

            int min = int.Parse(fiveLeft) + int.Parse(fiveRight);
            int max = int.Parse(sixLeft) + int.Parse(sixRight);

            sw.WriteLine($"{min} {max}");

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}

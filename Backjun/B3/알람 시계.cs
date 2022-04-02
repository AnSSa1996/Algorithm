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

            int Minutes = inputs[0] * 60 + inputs[1];
            Minutes -= 45;

            if (Minutes < 0)
            {
                Minutes = 1440 + Minutes;
            }

            int hour = Minutes / 60;
            int minute = Minutes % 60;

            sw.WriteLine($"{hour} {minute}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

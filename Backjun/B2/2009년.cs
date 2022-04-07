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

            int[] months = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] days = new string[7] { "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", "Monday", "Tuesday" };

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int day = inputs[0];
            int month = inputs[1];

            int total = day;
            for (int i = 0; i < month - 1; i++)
            {
                total += months[i];
            }

            sw.WriteLine(days[total % 7]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
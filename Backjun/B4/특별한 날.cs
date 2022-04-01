using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            string result = "Before";

            int month = int.Parse(sr.ReadLine());
            int day = int.Parse(sr.ReadLine());

            if (month > 2) result = "After";
            else if (month == 2 && day > 18) result = "After";
            else if (month == 2 && day == 18) result = "Special";

            sw.Write(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

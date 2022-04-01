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

            int input = int.Parse(sr.ReadLine());

            if (input == 0) sw.WriteLine("YONSEI");
            else sw.WriteLine("Leading the Way to the Future");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

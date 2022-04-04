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

            int cost = 1000 - int.Parse(sr.ReadLine());

            int count = 0;
            count += cost / 500;
            cost %= 500;
            count += cost / 100;
            cost %= 100;
            count += cost / 50;
            cost %= 50;
            count += cost / 10;
            cost %= 10;
            count += cost / 5;
            cost %= 5;
            count += cost;

            sw.WriteLine(count);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}

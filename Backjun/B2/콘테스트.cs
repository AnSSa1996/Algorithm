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

            List<int> WU = new List<int>();
            List<int> KU = new List<int>();

            for (int i = 0; i < 10; i++) WU.Add(int.Parse(sr.ReadLine()));
            for (int i = 0; i < 10; i++) KU.Add(int.Parse(sr.ReadLine()));

            int WSum = WU.OrderByDescending(x => x).Take(3).Sum();
            int KSum = KU.OrderByDescending(x => x).Take(3).Sum();

            sw.WriteLine($"{WSum} {KSum}");

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}

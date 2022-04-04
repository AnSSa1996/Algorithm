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

            List<int> lst = new List<int>();

            for (int i = 0; i < 5; i++) lst.Add(int.Parse(sr.ReadLine()));

            lst.Sort();

            sw.WriteLine(lst.Sum() / 5);
            sw.WriteLine(lst[2]);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}

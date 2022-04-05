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

            string[] str = sr.ReadLine().Split(',');

            sw.WriteLine(str.Length);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}

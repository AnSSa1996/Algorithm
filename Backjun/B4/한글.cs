using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int index = int.Parse(sr.ReadLine());

            var ga = '가' + index - 1;

            sw.WriteLine((char)ga);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

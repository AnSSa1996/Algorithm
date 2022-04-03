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

            string name = sr.ReadLine();

            sw.WriteLine(":fan::fan::fan:");
            sw.WriteLine($":fan::{name}::fan:");
            sw.WriteLine(":fan::fan::fan:");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

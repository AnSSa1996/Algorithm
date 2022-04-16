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

            sw.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-dd"));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

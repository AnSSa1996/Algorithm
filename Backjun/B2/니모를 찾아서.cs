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

            while (true)
            {
                string str = sr.ReadLine();
                if (str == "EOI") break;
                if (str.ToLower().Contains("nemo")) sw.WriteLine("Found");
                else sw.WriteLine("Missing");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
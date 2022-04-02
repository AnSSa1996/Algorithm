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

            while (true)
            {
                string input = sr.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;
                sw.WriteLine(input);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

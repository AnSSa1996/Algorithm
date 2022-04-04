using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            string str = new string(sr.ReadLine().Split('-').Select(x => x[0]).ToArray());
            sw.WriteLine(str);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}

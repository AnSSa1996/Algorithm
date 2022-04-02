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

            long fisrt = Convert.ToInt64(sr.ReadLine(), 2);
            long second = Convert.ToInt64(sr.ReadLine(), 2);

            string bit = Convert.ToString(fisrt * second, 2);

            sw.WriteLine(bit);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

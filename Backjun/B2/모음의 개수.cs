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

            int count = sr.ReadLine().ToArray().
                Where(x => x == 'a' || x == 'e' || x == 'i' || x == 'o' || x == 'u').Count();

            sw.WriteLine(count);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}

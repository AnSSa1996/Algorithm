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

            char[] charArray = sr.ReadLine().ToArray();
            var sortedChar = charArray.OrderByDescending(x => x).ToArray();
            sw.WriteLine(new string(sortedChar));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
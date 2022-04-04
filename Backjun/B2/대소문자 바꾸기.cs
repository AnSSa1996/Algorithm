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

            string str = sr.ReadLine();

            string reverseStr = new string(str.ToArray().
                Select(x => x >= 'a' ? (char)(x - 32) : (char)(x + 32)).ToArray());

            sw.WriteLine(reverseStr);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}

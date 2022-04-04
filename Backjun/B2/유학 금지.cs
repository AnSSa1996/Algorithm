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

            string str = sr.ReadLine();
            string newStr = str.Replace("C", "").Replace("A", "").Replace("M", "").Replace("B", "").Replace("R", "")
                .Replace("I", "").Replace("D", "").Replace("G", "").Replace("E", "");

            sw.WriteLine(newStr);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

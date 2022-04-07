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
            if (str == new string(str.Reverse().ToArray())) sw.WriteLine("true");
            else sw.WriteLine("false");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
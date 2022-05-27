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

            string s = sr.ReadLine();
            if (s == "N" || s == "n") sw.WriteLine("Naver D2");
            else sw.WriteLine("Naver Whale");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

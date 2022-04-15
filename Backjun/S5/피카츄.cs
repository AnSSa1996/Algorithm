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

            str = str.Replace("pi", "*");
            str = str.Replace("ka", "*");
            str = str.Replace("chu", "*");

            if (str.Count(x => x != '*') == 0) sw.WriteLine("YES");
            else sw.WriteLine("NO");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

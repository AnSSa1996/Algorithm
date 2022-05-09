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
            int a = str[0] - '0'; int b = str[4] - '0'; int c = str[8] - '0';

            if (a + b == c) sw.WriteLine("YES");
            else sw.WriteLine("NO");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

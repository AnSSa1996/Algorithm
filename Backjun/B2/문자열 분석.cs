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

            while (true)
            {
                string str = sr.ReadLine();
                if (str == null) break;
                int small = 0;
                int big = 0;
                int num = 0;
                int space = 0;
                foreach (char c in str)
                {
                    if (c == ' ') space++;
                    else if (c >= 'a' && c <= 'z') small++;
                    else if (c >= 'A' && c <= 'Z') big++;
                    else if (c >= '0' && c <= '9') num++;
                }

                sw.WriteLine($"{small} {big} {num} {space}");
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}

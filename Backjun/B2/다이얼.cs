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

            string str = sr.ReadLine();
            int count = str.ToArray().Sum(x => check(x));

            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static int check(char c)
        {
            int n = c - 'A';
            int result;

            if (n <= 2) result = 3;
            else if (n <= 5) result = 4;
            else if (n <= 8) result = 5;
            else if (n <= 11) result = 6;
            else if (n <= 14) result = 7;
            else if (n <= 18) result = 8;
            else if (n <= 21) result = 9;
            else result = 10;

            return result;
        }
    }
}

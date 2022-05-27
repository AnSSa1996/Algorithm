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

            int N = int.Parse(sr.ReadLine());
            string[] str = sr.ReadLine().Split();

            bool check = true;
            char first = str[0][0];
            for (int i = 1; i < str.Length; i++)
            {
                if (first != str[i][0]) { check = false; break; }
            }

            if (check) sw.WriteLine("1");
            else sw.WriteLine("0");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

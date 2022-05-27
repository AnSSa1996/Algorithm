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
            for (int i = 0; i < N; i++)
            {
                string str = sr.ReadLine().ToLower();
                string reverseStr = new string(str.Reverse().ToArray());

                if (str == reverseStr) sw.WriteLine("Yes");
                else sw.WriteLine("No");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

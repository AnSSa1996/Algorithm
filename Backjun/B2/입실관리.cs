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

            long N = long.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string str = sr.ReadLine().ToLower();
                sw.WriteLine(str);
            }


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
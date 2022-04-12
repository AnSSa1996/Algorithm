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

            int N = int.Parse(sr.ReadLine()); sr.ReadLine();
            for (int i = 0; i < N; i++) sw.WriteLine("yes");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
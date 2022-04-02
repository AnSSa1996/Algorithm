using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder resultSb = new StringBuilder();

            int N = int.Parse(sr.ReadLine());

            for(int i = N; i>0; i--)
            {
                sw.WriteLine(i);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

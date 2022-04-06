using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            int N = int.Parse(sr.ReadLine());
            for (int i = 1; i <= N; i++)
            {
                string str = sr.ReadLine();
                sw.WriteLine($"{i}. {str}");
            }


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
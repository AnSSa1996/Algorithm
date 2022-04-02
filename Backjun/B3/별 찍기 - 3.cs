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
            StringBuilder sb = new StringBuilder();

            int num = int.Parse(sr.ReadLine());

            for (int i = num; i > 0; i--)
            {
                sb.Append(String.Concat(Enumerable.Repeat("*", i))).AppendLine();
            }

            sw.WriteLine(sb.ToString());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

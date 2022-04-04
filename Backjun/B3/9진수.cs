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

            int N = int.Parse(sr.ReadLine());

            StringBuilder sb = new StringBuilder();
            Convert9(N, 9, sb);

            sw.WriteLine(new String(sb.ToString().Reverse().ToArray()));

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static void Convert9(int a, int b, StringBuilder sb)
        {
            int temp = a / b;
            sb.Append(a % b);

            if (temp >= b) Convert9(temp, b, sb);
            else if (temp != 0) sb.Append(temp);
        }
    }
}

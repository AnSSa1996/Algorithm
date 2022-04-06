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

            for (int i = 1; i <= N; i++)
            {
                char[] charArray = sr.ReadLine().ToArray().Select(x => x + 1 <= 'Z' ? (char)(x + 1) : 'A').ToArray();
                sw.WriteLine($"String #{i}");
                sw.WriteLine(new string(charArray));
                if (i != N) sw.WriteLine();
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
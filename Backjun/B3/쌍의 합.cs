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

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(sr.ReadLine());
                StringBuilder tempSb = new StringBuilder();
                for (int first = 1; first < (num + 1) / 2; first++)
                {
                    tempSb.Append($" {first} {num - first},");
                }
                if (tempSb.Length > 0) tempSb.Remove(tempSb.Length - 1, 1);
                sw.WriteLine($"Pairs for {num}:{tempSb}");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

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

            for (int i = 0; i < N; i++)
            {
                string[] str = sr.ReadLine().Split();
                string left = str[0];
                string right = str[1];
                StringBuilder tempSb = new StringBuilder();
                for (int j = 0; j < left.Length; j++)
                {
                    int dif = right[j] - left[j] >= 0 ?
                        right[j] - left[j] :
                        right[j] + 26 - left[j];
                    tempSb.Append($" {dif}");
                }
                sw.WriteLine($"Distances:{tempSb}");
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}

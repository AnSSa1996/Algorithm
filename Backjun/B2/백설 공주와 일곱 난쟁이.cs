using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            List<int> small = new List<int>();

            for (int i = 0; i < 9; i++)
            {
                small.Add(int.Parse(sr.ReadLine()));
            }

            int sum = small.Sum();

            for (int i = 0; i < 8; i++)
            {
                for (int j = i + 1; j < 9; j++)
                {
                    if (sum - small[i] - small[j] == 100)
                    {
                        small.RemoveAt(i);
                        small.RemoveAt(j - 1);
                        goto end;
                    }
                }
            }

        end:
            sw.WriteLine(string.Join("\n", small));

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}

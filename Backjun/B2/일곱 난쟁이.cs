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

            List<int> small9 = new List<int>();

            for (int i = 0; i < 9; i++)
            {
                small9.Add(int.Parse(sr.ReadLine()));
            }

            small9.Sort();
            int totalSum = small9.Sum();

            for (int i = 0; i < 8; i++)
            {
                for (int j = i + 1; j < 9; j++)
                {
                    if (totalSum - small9[i] - small9[j] == 100)
                    {
                        small9.RemoveAt(i);
                        small9.RemoveAt(j - 1);
                        goto end;
                    }
                }
            }

        end:
            sw.WriteLine(string.Join("\n", small9));

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
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

            for (int i = 0; i < 3; i++)
            {
                string str = sr.ReadLine();
                int max = 1;
                int currentMax = 1;
                for (int j = 0; j < 7; j++)
                {
                    if (str[j] == str[j + 1])
                    {
                        currentMax++;
                        max = Math.Max(max, currentMax);
                    }
                    else
                    {
                        currentMax = 1;
                    }
                }
                sw.WriteLine(max);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
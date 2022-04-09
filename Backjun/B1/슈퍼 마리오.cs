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

            int currentMin = 0;
            int total = 0;

            for (int i = 0; i < 10; i++)
            {
                int current = int.Parse(sr.ReadLine());
                total += current;
                if (total >= 100)
                {
                    if (Math.Abs(total - 100) <= Math.Abs(total - current - 100))
                    {
                        currentMin = total;
                    }
                    else
                    {
                        currentMin = total - current;
                    }
                    break;
                }
                currentMin = total;
            }

            sw.WriteLine(currentMin);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
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

            for (int a = 6; a <= 100; a++)
            {
                for (int b = 2; b < a; b++)
                {
                    for (int c = b + 1; c < a; c++)
                    {
                        for (int d = c + 1; d < a; d++)
                        {
                            if (a * a * a == b * b * b + c * c * c + d * d * d)
                            {
                                sw.WriteLine($"Cube = {a}, Triple = ({b},{c},{d})");
                            }
                        }
                    }
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
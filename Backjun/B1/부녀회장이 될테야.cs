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

            for (int i = 0; i < N; i++)
            {
                int floor = int.Parse(sr.ReadLine());
                int number = int.Parse(sr.ReadLine());

                int[] rooms = Enumerable.Repeat(1, number + 1).ToArray();
                for (int f = 1; f <= floor + 1; f++)
                {
                    for (int n = 1; n < number; n++)
                    {
                        rooms[n] += rooms[n - 1];
                    }
                }
                sw.WriteLine(rooms[number - 1]);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
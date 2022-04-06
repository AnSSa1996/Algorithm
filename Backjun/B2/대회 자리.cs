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
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int repeat = inputs[0];
                int seat_Count = inputs[1];

                bool[] seats = new bool[seat_Count + 1];
                int count = 0;

                for (int j = 0; j < repeat; j++)
                {
                    int seat_N = int.Parse(sr.ReadLine());
                    if (seats[seat_N] == false) seats[seat_N] = true;
                    else count++;
                }

                sw.WriteLine(count);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
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

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int H = inputs[0];
                int roomsNum = inputs[2];

                int BackNum = (roomsNum + H - 1) / H;
                int FrontNum = (roomsNum % H == 0) ? H : roomsNum % H;
                sw.WriteLine($"{FrontNum}{BackNum:00}");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

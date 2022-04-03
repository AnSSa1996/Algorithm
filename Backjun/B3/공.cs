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

            bool[] cups = new bool[4];
            cups[1] = true;

            int N = int.Parse(sr.ReadLine());
            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int left = inputs[0];
                int right = inputs[1];
                bool tempLeft = cups[left];
                cups[left] = cups[right];
                cups[right] = tempLeft;
            }

            for (int i = 1; i < 4; i++) if (cups[i]) sw.WriteLine(i);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
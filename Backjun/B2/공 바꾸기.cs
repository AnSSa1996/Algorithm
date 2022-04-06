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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int N = inputs[0];
            int ball_Count = inputs[1];

            int[] balls = Enumerable.Range(1, N).ToArray();

            for (int i = 0; i < ball_Count; i++)
            {
                int[] changes = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                int temp = balls[changes[0] - 1];
                balls[changes[0] - 1] = balls[changes[1] - 1];
                balls[changes[1] - 1] = temp;
            }

            sw.WriteLine(string.Join(" ", balls));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
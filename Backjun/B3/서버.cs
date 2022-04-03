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
            int Time = inputs[1];
            int[] works = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int count = 0;

            for (int i = 0; i < N; i++)
            {
                Time -= works[i];
                if (Time < 0) break;
                count++;
            }

            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

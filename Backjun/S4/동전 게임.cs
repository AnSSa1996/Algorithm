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

            int round = int.Parse(sr.ReadLine());
            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                int left = inputs[0];
                int right = inputs[1];

                if (left == right) { sw.WriteLine(1); continue; }
                int dif = Math.Abs(left - right);
                int remainRound = round - Math.Max(left, right);

                if (left > right && (dif - remainRound) <= 2) { sw.WriteLine(1); continue; } // 먼저 던지는 경우
                else if (left < right && (dif - remainRound) <= 1) { sw.WriteLine(1); continue; } // 뒤에 던지는 경우

                sw.WriteLine(0);
            }


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());
            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            List<int> dice = new List<int>();
            dice.Add(Math.Min(inputs[0], inputs[5]));
            dice.Add(Math.Min(inputs[1], inputs[4]));
            dice.Add(Math.Min(inputs[2], inputs[3]));
            dice.Sort();
            long one = dice[0];
            long two = dice[0] + dice[1];
            long three = dice[0] + dice[1] + dice[2];
            long result = 0;


            // 가장 위에 있는 꼭지점 네개;
            result += three * 4;

            // 가장 위에 있는 꼭지점 네개를 제외한 주사위들
            if (N - 2 > 0)
            {
                result += two * (N - 2) * 4;
                result += one * (N - 2) * (N - 2);
            }

            // 가장 위에 있는 주사위를 제외한 주사위들
            result += two * 4 * (N - 1);
            if (N - 2 > 0)
            {
                result += one * (N - 2) * (N - 1) * 4;
            }

            if (N == 1)
            {
                Array.Sort(inputs);
                result = inputs[0..5].Sum();
            }

            sw.WriteLine(result);
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

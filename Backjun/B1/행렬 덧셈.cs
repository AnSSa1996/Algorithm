using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder resultSb = new StringBuilder();

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int Y = inputs[0];
            int X = inputs[1];

            int[,] result = new int[Y, X];

            for (int y = 0; y < Y * 2; y++)
            {
                int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int x = 0; x < X; x++)
                {
                    result[y % Y, x] += nums[x];
                }
            }



            for (int y = 0; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    if (x != (X - 1)) resultSb.Append($"{result[y, x]} ");
                    else resultSb.AppendLine($"{result[y, x]}");
                }
            }

            sw.WriteLine(resultSb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
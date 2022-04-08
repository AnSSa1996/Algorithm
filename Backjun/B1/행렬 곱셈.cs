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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int firstY = inputs[0];
            int firstX = inputs[1];

            List<List<int>> first = new List<List<int>>();
            for (int i = 0; i < firstY; i++) first.Add(Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList());


            int[] inputs2 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int secondY = inputs2[0];
            int secondX = inputs2[1];

            List<List<int>> second = new List<List<int>>();
            for (int i = 0; i < secondY; i++) second.Add(Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList());


            StringBuilder result = new StringBuilder();

            for (int z = 0; z < firstY; z++)
            {
                for (int y = 0; y < secondX; y++)
                {
                    int temp = 0;
                    for (int x = 0; x < firstX; x++)
                    {
                        temp += first[z][x] * second[x][y];
                    }
                    if (y != firstY - 1) result.Append($"{temp} ");
                    else result.AppendLine($"{temp}");
                }
            }

            sw.Write(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
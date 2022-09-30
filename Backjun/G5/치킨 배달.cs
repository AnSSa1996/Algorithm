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
            int N = inputs[0]; int M = inputs[1];
            List<(int Y, int X)> homePosList = new List<(int Y, int X)>();
            List<(int Y, int X)> chickenPosList = new List<(int Y, int X)>();

            for (int y = 0; y < N; y++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int x = 0; x < N; x++)
                {
                    if (inputs[x] == 1) homePosList.Add((y, x));
                    if (inputs[x] == 2) chickenPosList.Add((y, x));
                }
            }

            int TotalChickenCount = chickenPosList.Count();

            List<(int Y, int X)> currentChickenList = new List<(int Y, int X)>();
            int result = int.MaxValue;
            DFS(0, 0);
            sw.WriteLine(result);

            void DFS(int currentChickenCount, int index)
            {
                if (currentChickenCount == M)
                {
                    result = Math.Min(result, CalCulate());
                    return;
                }

                for (int current = index; current < TotalChickenCount; current++)
                {
                    currentChickenList.Add(chickenPosList[current]);
                    DFS(currentChickenCount + 1, current + 1);
                    currentChickenList.RemoveAt(currentChickenList.Count() - 1);
                }
            }

            int CalCulate()
            {
                int sum = 0;
                foreach (var homePos in homePosList)
                {
                    int min = int.MaxValue;
                    foreach (var chic in currentChickenList)
                    {
                        int current = Math.Abs(homePos.X - chic.X) + Math.Abs(homePos.Y - chic.Y);
                        min = Math.Min(min, current);
                    }
                    sum += min;
                }

                return sum;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
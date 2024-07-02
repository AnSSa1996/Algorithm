using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int T = int.Parse(Console.ReadLine());
        for (int t = 0; t < T; t++)
        {
            int N = int.Parse(Console.ReadLine());
            var points = new List<Point>();
            int totalX = 0, totalY = 0;

            for (int i = 0; i < N; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                points.Add(new Point(input[0], input[1]));
                totalX += input[0];
                totalY += input[1];
            }

            double minDistance = double.MaxValue;
            RecursiveCombination(points, new List<Point>(), 0, N / 2, ref minDistance, totalX, totalY);
            
            Console.WriteLine($"{minDistance:F12}");
        }
    }

    static void RecursiveCombination(List<Point> allPoints, List<Point> currentCombination, int startIndex, int leftToPick, ref double minDistance, int totalX, int totalY)
    {
        if (leftToPick == 0)
        {
            int currentX = 0, currentY = 0;
            foreach (var p in currentCombination)
            {
                currentX += p.X;
                currentY += p.Y;
            }
            int remainingX = totalX - currentX;
            int remainingY = totalY - currentY;
            double distance = Math.Sqrt(Math.Pow(remainingX - currentX, 2) + Math.Pow(remainingY - currentY, 2));
            minDistance = Math.Min(minDistance, distance);
            return;
        }
        
        for (int i = startIndex; i <= allPoints.Count - leftToPick; i++)
        {
            currentCombination.Add(allPoints[i]);
            RecursiveCombination(allPoints, currentCombination, i + 1, leftToPick - 1, ref minDistance, totalX, totalY);
            currentCombination.RemoveAt(currentCombination.Count - 1);
        }
    }
}

struct Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

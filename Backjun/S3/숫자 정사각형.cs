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

            int Y = inputs[0]; int X = inputs[1];
            List<List<char>> board = new List<List<char>>();
            for (int i = 0; i < inputs[0]; i++) board.Add(sr.ReadLine().ToList());
            int min = Math.Min(Y, X);

            int maxY = Y - min; int maxX = X - min;
            int max = 1;
            for (int startY = 0; startY < Y; startY++)
            {
                for (int startX = 0; startX < X; startX++)
                {
                    for (int length = 1; length < min; length++)
                    {
                        if (startY + length >= Y || startX + length >= X) break;
                        char currentChar = board[startY][startX];
                        if (currentChar == board[startY][startX + length] &&
                            currentChar == board[startY + length][startX] &&
                            currentChar == board[startY + length][startX + length])
                            max = Math.Max(max, (length + 1) * (length + 1));
                    }
                }
            }

            sw.WriteLine(max);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

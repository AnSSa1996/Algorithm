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
            StringBuilder sb = new StringBuilder();

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int rows = inputs[0]; int columns = inputs[1]; int second = inputs[2];

            char[,] firstBoard = new char[rows, columns];
            char[,] secondBoard = new char[rows, columns];
            char[,] thirdBoard = new char[rows, columns];
            char[,] lastBoard = new char[rows, columns];

            for (int r = 0; r < rows; r++)
            {
                var chars = sr.ReadLine().ToCharArray();
                for (int c = 0; c < columns; c++)
                {
                    firstBoard[r, c] = chars[c];
                    secondBoard[r, c] = 'O';
                    if (chars[c] == '.') thirdBoard[r, c] = '1';
                    else thirdBoard[r, c] = '2';
                }
            }


            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (thirdBoard[r, c] == '2')
                    {
                        SanghunSolution(r, c);
                    }
                }
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (thirdBoard[r, c] == '1') { lastBoard[r, c] = '7'; }
                    else lastBoard[r, c] = '6';
                }
            }


            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (lastBoard[r, c] == '7')
                    {
                        SanghunSolution2(r, c);
                    }
                }
            }


            var result = second % 4;
            if (second == 1)
            {
                PrintResult(firstBoard);
            }
            else if (result % 2 == 0)
            {
                PrintResult(secondBoard);
            }
            else if (result % 4 == 1)
            {
                PrintResult(lastBoard);
            }
            else if (result % 4 == 3)
            {
                PrintResult(thirdBoard);
            }

            sb.Remove(sb.Length - 1, 1);
            sw.WriteLine(sb);

            void SanghunSolution(int X, int Y)
            {
                int[] dx = new int[4] { 1, -1, 0, 0 };
                int[] dy = new int[4] { 0, 0, 1, -1 };
                thirdBoard[X, Y] = '3';
                for (int d = 0; d < 4; d++)
                {
                    var nextX = X + dx[d];
                    var nextY = Y + dy[d];

                    if (nextX < 0 || nextX >= rows || nextY < 0 || nextY >= columns) continue;
                    if (thirdBoard[nextX, nextY] == '2') continue;
                    if (thirdBoard[nextX, nextY] == '3') continue;

                    thirdBoard[nextX, nextY] = '3';
                }
            }

            void SanghunSolution2(int X, int Y)
            {
                int[] dx = new int[4] { 1, -1, 0, 0 };
                int[] dy = new int[4] { 0, 0, 1, -1 };
                lastBoard[X, Y] = '8';
                for (int d = 0; d < 4; d++)
                {
                    var nextX = X + dx[d];
                    var nextY = Y + dy[d];

                    if (nextX < 0 || nextX >= rows || nextY < 0 || nextY >= columns) continue;
                    if (lastBoard[nextX, nextY] == '7') { continue; }
                    if (lastBoard[nextX, nextY] == '8') continue;

                    lastBoard[nextX, nextY] = '8';
                }
            }

            void PrintResult(char[,] results)
            {
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        char character = results[r, c];
                        if (character == '1') character = 'O';
                        if (character == '3') character = '.';
                        if (character == '6') character = 'O';
                        if (character == '8') character = '.';
                        sb.Append($"{character}");
                    }
                    sb.AppendLine();
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

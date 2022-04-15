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

            int[] dx = new int[8] { 2, 2, 1, 1, -1, -1, -2, -2 };
            int[] dy = new int[8] { 1, -1, 2, -2, 2, -2, 1, -1 };

            bool[,] board = new bool[6, 6];

            string first = sr.ReadLine();

            int currentY = first[0] - 'A';
            int currentX = first[1] - '1';
            board[currentY, currentX] = true;
            bool check = true;
            for (int i = 1; i < 36; i++)
            {
                string strs = sr.ReadLine();
                int nextY = strs[0] - 'A';
                int nextX = strs[1] - '1';

                if (board[nextY, nextX])
                {
                    check = false;
                    break;
                }
                for (int j = 0; j < 8; j++)
                {
                    int checkY = currentY + dy[j];
                    int checkX = currentX + dx[j];

                    if (nextY == checkY && nextX == checkX)
                    {
                        currentY = nextY; currentX = nextX;
                        board[nextY, nextX] = true;
                        goto end;
                    }
                }
                check = false;
                break;
            end:;

                if (i == 35)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        int checkY = nextY + dy[j];
                        int checkX = nextX + dx[j];

                        if ((first[0] - 'A') == checkY && (first[1] - '1') == checkX)
                        {
                            currentY = nextY; currentX = nextX;
                            board[nextY, nextX] = true;
                            break;
                        }
                        if (j == 7) check = false;
                    }
                }
            }

            if (check) sw.WriteLine("Valid");
            else sw.WriteLine("Invalid");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

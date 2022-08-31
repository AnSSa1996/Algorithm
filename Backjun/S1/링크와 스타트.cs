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

            int N = int.Parse(sr.ReadLine());
            int[,] board = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                var array = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int j = 0; j < N; j++)
                {
                    board[i, j] = array[j];
                }
            }

            bool[] check = new bool[N];

            int total = N / 2;
            long min = long.MaxValue;

            for (int i = 0; i < total; i++)
            {
                SanghunSolution(i, total);
            }

            sw.WriteLine(min);

            void SanghunSolution(int index, int count)
            {
                CheckSoultion();
                if (count == 0)
                {
                    return;
                }

                for (int i = index; i < N; i++)
                {
                    if (check[i]) continue;
                    check[i] = true;
                    SanghunSolution(i, count - 1);
                    check[i] = false;
                }
            }

            void CheckSoultion()
            {
                long startTeam = 0;
                long linkTeam = 0;

                for (int a = 0; a < N; a++)
                {
                    for (int b = a; b < N; b++)
                    {
                        if (a == b) continue;
                        if (check[a] && check[b])
                        {
                            startTeam += board[a, b] + board[b, a];
                        }
                        else if (check[a] == false && check[b] == false)
                        {
                            linkTeam += board[a, b] + board[b, a];
                        }
                    }
                }

                long result = Math.Abs(startTeam - linkTeam);
                min = Math.Min(min, result);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

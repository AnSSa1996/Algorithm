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

            int N = int.Parse(sr.ReadLine());
            int count = N / 2;

            List<List<int>> board = new List<List<int>>();

            for (int i = 0; i < N; i++)
            {
                List<int> lst = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
                board.Add(lst);
            }
            List<int> answerLst = new List<int>();
            bool[] check = new bool[N + 1];

            DFS(0, 0);

            sw.WriteLine(answerLst.Min());

            void DFS(int K, int currentN)
            {
                if (count == K)
                {
                    List<int> A = new List<int>();
                    List<int> B = new List<int>();

                    for (int i = 1; i <= N; i++)
                    {
                        if (check[i] == true) A.Add(i);
                        else B.Add(i);
                    }

                    int A_Total = 0;
                    int B_Total = 0;

                    for (int a = 0; a < count - 1; a++)
                    {
                        for (int b = a + 1; b < count; b++)
                        {
                            A_Total += board[A[a] - 1][A[b] - 1] + board[A[b] - 1][A[a] - 1];
                            B_Total += board[B[b] - 1][B[a] - 1] + board[B[a] - 1][B[b] - 1];
                        }
                    }

                    answerLst.Add(Math.Abs(A_Total - B_Total));
                }
                else
                {
                    for (int i = 1; i <= N; i++)
                    {
                        if (check[i] == false && i > currentN)
                        {
                            check[i] = true;
                            DFS(K + 1, i);
                            check[i] = false;
                        }
                    }
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
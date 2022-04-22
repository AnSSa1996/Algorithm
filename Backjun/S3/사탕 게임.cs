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
            List<char[]> lst = new List<char[]>();

            for (int i = 0; i < N; i++) lst.Add(sr.ReadLine().ToArray());

            int max = 1;
            for (int a = 0; a < N; a++)
            {
                for (int b = 0; b < N - 1; b++)
                {
                    char temp = lst[a][b];
                    lst[a][b] = lst[a][b + 1];
                    lst[a][b + 1] = temp;

                    int cnt = MaxSuccess(lst, N);
                    max = Math.Max(max, cnt);

                    temp = lst[a][b];
                    lst[a][b] = lst[a][b + 1];
                    lst[a][b + 1] = temp;
                }

                for (int b = 0; b < N - 1; b++)
                {
                    char temp = lst[b][a];
                    lst[b][a] = lst[b + 1][a];
                    lst[b + 1][a] = temp;

                    int cnt = MaxSuccess(lst, N);
                    max = Math.Max(max, cnt);

                    temp = lst[b][a];
                    lst[b][a] = lst[b + 1][a];
                    lst[b + 1][a] = temp;
                }
            }

            sw.WriteLine(max);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static int MaxSuccess(List<char[]> lst, int N)
        {
            int cnt = 1;

            int columnMax = 1;
            int rowMax = 1;
            for (int a = 0; a < N; a++)
            {
                int columns = 1;
                for (int b = 0; b < N - 1; b++)
                {
                    if (lst[a][b] == lst[a][b + 1])
                    { columns++; columnMax = Math.Max(columnMax, columns); }
                    else { columns = 1; }
                }

                int rows = 1;

                for (int b = 0; b < N - 1; b++)
                {
                    if (lst[b][a] == lst[b + 1][a])
                    { rows++; rowMax = Math.Max(rowMax, rows); }
                    else { rows = 1; }
                }
            }
            cnt = Math.Max(columnMax, rowMax);
            return cnt;
        }
    }
}
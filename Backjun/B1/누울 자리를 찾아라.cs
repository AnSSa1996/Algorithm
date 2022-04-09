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

            List<string> str = new List<string>();

            for (int i = 0; i < N; i++) str.Add(sr.ReadLine());

            int rowTotal = 0;
            int colTotal = 0;

            for (int y = 0; y < N; y++)
            {
                int rowCnt = 0;
                int colCnt = 0;

                for (int x = 0; x < N; x++)
                {
                    if (str[y][x] == '.') rowCnt++;
                    else if (str[y][x] == 'X') rowCnt = 0;

                    if (str[x][y] == '.') colCnt++;
                    else if (str[x][y] == 'X') colCnt = 0;

                    if (rowCnt == 2) rowTotal++;
                    if (colCnt == 2) colTotal++;
                }
            }

            sw.WriteLine($"{rowTotal} {colTotal}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
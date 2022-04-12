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
            int Y = inputs[0];
            int X = inputs[1];

            int row = 0;
            int col = 0;

            List<string> lst = new List<string>();

            for (int i = 0; i < Y; i++)
            {
                string str = sr.ReadLine();
                lst.Add(str);
                if (str.Count(x => x == 'X') == 0) row++;
            }

            for (int x = 0; x < X; x++)
            {
                int cnt = 0;
                for (int y = 0; y < Y; y++) if (lst[y][x] == '.') cnt++;
                if (cnt == Y) col++;
            }

            sw.WriteLine(Math.Max(row, col));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
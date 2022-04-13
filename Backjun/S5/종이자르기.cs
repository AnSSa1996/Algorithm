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

            int columns = inputs[0];
            int rows = inputs[1];

            List<int> col_Lst = new List<int>() { 0, columns };
            List<int> row_Lst = new List<int>() { 0, rows };

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                int[] cuts = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                if (cuts[0] == 0) row_Lst.Add(cuts[1]);
                else col_Lst.Add(cuts[1]);
            }

            col_Lst.Sort(); row_Lst.Sort();

            List<int> cut_Col = new List<int>();
            List<int> cut_Row = new List<int>();

            for (int i = 1; i < col_Lst.Count(); i++) cut_Col.Add(col_Lst[i] - col_Lst[i - 1]);
            for (int i = 1; i < row_Lst.Count(); i++) cut_Row.Add(row_Lst[i] - row_Lst[i - 1]);

            sw.WriteLine(cut_Col.Max() * cut_Row.Max());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

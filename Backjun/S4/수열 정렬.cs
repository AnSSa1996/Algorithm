using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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

            List<int> lst = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();

            var sortedLst = lst.ToList();
            sortedLst.Sort();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                int index = sortedLst.IndexOf(lst[i]);
                sb.Append($"{index} ");
                sortedLst[index] = -1;
            }

            sb.Remove(sb.Length - 1, 1);
            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

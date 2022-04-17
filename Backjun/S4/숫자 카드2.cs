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
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            int N = int.Parse(sr.ReadLine());
            int[] A = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int M = int.Parse(sr.ReadLine());
            int[] B = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int[] cards = new int[20000001];

            Array.ForEach(A, x => cards[x + 10000000]++);

            StringBuilder resultSb = new StringBuilder();
            for (int i = 0; i < M; i++) resultSb.Append($"{cards[B[i] + 10000000]} ");

            resultSb.Remove(resultSb.Length - 1, 1);
            sw.WriteLine(resultSb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

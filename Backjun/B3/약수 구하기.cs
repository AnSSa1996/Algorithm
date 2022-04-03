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
            int N = inputs[0];
            int K = inputs[1];

            List<int> divList = new List<int>();

            for (int i = 1; i <= N; i++) if (N % i == 0) divList.Add(i);

            int result = 0;
            if (divList.Count >= K)
            {
                divList.Sort();
                result = divList[K - 1];
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

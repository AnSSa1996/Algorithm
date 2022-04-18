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

            for (int i = 0; i < N; i++)
            {
                HashSet<int> hash = new HashSet<int>();

                int n = int.Parse(sr.ReadLine());
                int[] memo1 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                Array.ForEach(memo1, a => hash.Add(a));

                int m = int.Parse(sr.ReadLine());
                int[] memo2 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                for (int j = 0; j < m; j++)
                {
                    if (hash.Contains(memo2[j])) sw.WriteLine(1);
                    else sw.WriteLine(0);
                }
            }


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

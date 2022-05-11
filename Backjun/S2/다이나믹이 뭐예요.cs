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
            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int n = inputs[0]; int m = inputs[1];
            long[,] D = new long[n + 3, m + 3];
            D[1, 1] = 1;

            for (int a = 1; a <= n; a++)
            {
                for (int b = 1; b <= m; b++)
                {
                    if (a <= n) D[a + 1, b] += D[a, b] % 1000000007;
                    if (b <= m) D[a, b + 1] += D[a, b] % 1000000007;
                    if (a <= n && b <= m) D[a + 1, b + 1] = D[a, b] % 1000000007;
                }
            }

            sw.WriteLine(D[n, m] % 1000000007);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

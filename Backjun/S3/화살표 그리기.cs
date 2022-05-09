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

            int T = int.Parse(sr.ReadLine());

            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

            for (int i = 0; i < T; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int color = inputs[1]; int point = inputs[0];
                if (dict.ContainsKey(color)) dict[color].Add(point);
                else dict.Add(color, new List<int>() { point });
            }

            BigInteger total = 0;
            foreach (var lst in dict.Values)
            {
                if (lst.Count <= 1) continue;
                lst.Sort();

                for (int i = 0; i < lst.Count; i++)
                {
                    if (i == 0) total += lst[i + 1] - lst[i];
                    else if (i == lst.Count - 1) total += lst[lst.Count - 1] - lst[lst.Count - 2];
                    else
                    {
                        int a = lst[i] - lst[i - 1];
                        int b = lst[i + 1] - lst[i];
                        total += Math.Min(a, b);
                    }
                }
            }

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

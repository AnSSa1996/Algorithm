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

            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                int color = inputs[1];
                int pos = inputs[0];

                if (dict.ContainsKey(color)) dict[color].Add(pos);
                else dict.Add(color, new List<int>() { pos });
            }

            int total = 0;
            foreach (var d in dict)
            {
                d.Value.Sort();
                for (int i = 0; i < d.Value.Count(); i++)
                {
                    if (i == 0) { total += d.Value[1] - d.Value[0]; continue; }
                    if (i == (d.Value.Count() - 1)) { total += d.Value[i] - d.Value[i - 1]; continue; }

                    if (d.Value[i] - d.Value[i - 1] < d.Value[i + 1] - d.Value[i]) total += d.Value[i] - d.Value[i - 1];
                    else total += d.Value[i + 1] - d.Value[i];
                }
            }

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

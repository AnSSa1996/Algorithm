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

            int T = int.Parse(sr.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(sr.ReadLine());
                Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

                for (int j = 0; j < N; j++)
                {
                    string[] inputs = sr.ReadLine().Split();
                    string category = inputs[1];
                    string name = inputs[0];

                    if (dict.ContainsKey(category)) dict[category].Add(name);
                    else dict.Add(category, new List<string>() { name });
                }

                long total = 1;
                foreach (var d in dict) total *= (d.Value.Count() + 1);

                sw.WriteLine(total - 1);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
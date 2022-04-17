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

            Dictionary<string, int> dict = new Dictionary<string, int>();

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string name = sr.ReadLine();
                if (dict.ContainsKey(name)) dict[name]++;
                else dict.Add(name, 1);
            }

            var sortedValue = dict.OrderByDescending(x => x.Value).ThenBy(x => x.Key).First().Key;

            sw.WriteLine(sortedValue);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

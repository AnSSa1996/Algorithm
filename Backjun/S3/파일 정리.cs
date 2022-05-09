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
            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < N; i++)
            {
                string[] inputs = sr.ReadLine().Split('.');
                string extension = inputs[1];

                if (dict.ContainsKey(extension)) dict[extension]++;
                else dict.Add(extension, 1);
            }

            var sortedDict = dict.OrderBy(x => x.Key);

            foreach (var d in sortedDict)
            {
                sw.WriteLine($"{d.Key} {d.Value}");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

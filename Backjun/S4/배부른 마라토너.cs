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
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < N; i++)
            {
                string str = sr.ReadLine();
                if (dict.ContainsKey(str)) dict[str]++;
                else dict.Add(str, 1);
            }

            for (int i = 0; i < N - 1; i++)
            {
                string str = sr.ReadLine();
                dict[str]--;
            }

            var find = dict.Where(x => x.Value == 1);

            sw.WriteLine(find.First().Key);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

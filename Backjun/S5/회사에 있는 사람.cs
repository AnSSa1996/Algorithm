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

            HashSet<string> hashSet = new HashSet<string>();

            for (int i = 0; i < N; i++)
            {
                string[] strs = sr.ReadLine().Split();
                string name = strs[0];
                string commute = strs[1];

                if (commute == "enter") hashSet.Add(name);
                else hashSet.Remove(name);
            }

            var sortedHash = hashSet.OrderByDescending(x => x);

            sw.WriteLine(string.Join("\n", sortedHash));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

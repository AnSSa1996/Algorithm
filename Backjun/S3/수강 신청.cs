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

            Dictionary<string, int> dict = new Dictionary<string, int>();

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int order = inputs[0]; int N = inputs[1];

            for (int i = 0; i < N; i++)
            {
                string str = sr.ReadLine();
                if (dict.ContainsKey(str)) { dict.Remove(str); dict.Add(str, i); }
                else dict.Add(str, i);
            }

            var answer = dict.OrderBy(a => a.Value).Take(order).Select(x => x.Key);
            sw.WriteLine(string.Join("\n", answer));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

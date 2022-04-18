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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = inputs[0]; int M = inputs[1];

            Dictionary<string, string> dict = new Dictionary<string, string>();

            for (int i = 0; i < N; i++)
            {
                string[] pw = sr.ReadLine().Split();
                dict.Add(pw[0], pw[1]);
            }

            for (int i = 0; i < M; i++)
            {
                string name = sr.ReadLine();
                sw.WriteLine(dict[name]);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

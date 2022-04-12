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

            for (int i = 0; i < N; i++)
            {
                List<string> lst = new List<string>();
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                for (int j = 0; j < inputs[0]; j++) lst.Add(new string(sr.ReadLine().Reverse().ToArray()));

                sw.WriteLine(string.Join("\n", lst));
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
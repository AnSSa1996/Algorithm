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

            Dictionary<string, int> dictIndex = new Dictionary<string, int>();
            Dictionary<int, string> dictName = new Dictionary<int, string>();

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int N = inputs[0];
            int M = inputs[1];

            for (int i = 1; i <= N; i++)
            {
                string name = sr.ReadLine();
                dictIndex.Add(name, i);
                dictName.Add(i, name);
            }

            for (int i = 0; i < M; i++)
            {
                string str = sr.ReadLine();
                int index = 0;
                if (int.TryParse(str, out index)) sw.WriteLine(dictName[index]);
                else sw.WriteLine(dictIndex[str]);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

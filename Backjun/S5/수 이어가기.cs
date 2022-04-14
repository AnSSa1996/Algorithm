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

            List<int> result = new List<int>();
            int max = 0;
            for (int i = 1; i <= N; i++)
            {
                List<int> temp = new List<int>();
                temp.Add(N);
                temp.Add(i);
                int total = N;
                int index = 0;
                while (true)
                {
                    if (temp[index] - temp[index + 1] >= 0) { temp.Add(temp[index] - temp[index + 1]); index++; }
                    else break;
                }
                if (max < temp.Count) { result = temp; max = temp.Count; }
            }

            sw.WriteLine(result.Count);
            sw.WriteLine(string.Join(" ", result));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

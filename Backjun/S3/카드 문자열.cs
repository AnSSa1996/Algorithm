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
                char[] charArray = sr.ReadLine().Split().Select(x => x[0]).ToArray();
                List<char> lst = new List<char>();
                char first = charArray[0];
                lst.Add(first);

                for (int j = 1; j < N; j++)
                {
                    if (first < charArray[j]) lst.Add(charArray[j]);
                    else
                    {
                        first = charArray[j];
                        lst.Insert(0, first);
                    }
                }
                sw.WriteLine(new string(lst.ToArray()));
            }
            sw.Flush();
            sw.Close();
            sr.Close();
        }

    }
}

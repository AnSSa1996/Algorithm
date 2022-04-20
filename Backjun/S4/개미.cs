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

            char[] left = sr.ReadLine().Reverse().ToArray();
            char[] right = sr.ReadLine().ToArray();

            List<char> lst = new List<char>();
            lst.AddRange(left); lst.AddRange(right);

            int time = int.Parse(sr.ReadLine());

            for (int i = 0; i < time; i++)
            {
                for (int j = 0; j < (lst.Count - 1); j++)
                {
                    if (left.Contains(lst[j]) && !left.Contains(lst[j + 1]))
                    {
                        char temp = lst[j];
                        lst[j] = lst[j + 1];
                        lst[j + 1] = temp;
                        j++;
                    }
                }
            }

            sw.WriteLine(string.Concat(lst));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

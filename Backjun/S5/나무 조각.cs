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

            List<int> lst = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (lst[j] > lst[j + 1])
                    {
                        int temp = lst[j];
                        lst[j] = lst[j + 1];
                        lst[j + 1] = temp;
                        sw.WriteLine($"{string.Join(" ", lst.Select(x => x.ToString()).ToArray())}");
                    }
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

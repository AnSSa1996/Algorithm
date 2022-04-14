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

            string answer = sr.ReadLine();

            int N = int.Parse(sr.ReadLine());

            int cnt = 0;
            for (int i = 0; i < N; i++)
            {
                List<char> lst = sr.ReadLine().ToList();
                for (int j = 0; j < lst.Count(); j++)
                {
                    string newString = new string(lst.ToArray());
                    if (newString.Contains(answer))
                    {
                        cnt++;
                        break;
                    }
                    lst.Add(lst[0]);
                    lst.RemoveAt(0);
                }
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

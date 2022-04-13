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

            List<int> lst = new List<int>();
            int N = int.Parse(sr.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string str = sr.ReadLine();
                if (str == "all") { lst = Enumerable.Range(1, 20).ToList(); continue; }
                else if (str == "empty") { lst.Clear(); continue; }

                string[] strArray = str.Split();
                string ope = strArray[0];
                int num = int.Parse(strArray[1]);

                solution(ope, num);
            }

            sw.Flush();
            sw.Close();
            sr.Close();

            void solution(string str, int num)
            {
                if (str == "add") lst.Add(num);
                else if (str == "remove") lst.Remove(num);
                else if (str == "check")
                {
                    if (lst.Contains(num)) sw.WriteLine(1);
                    else sw.WriteLine(0);
                }
                else if (str == "toggle")
                {
                    if (lst.Contains(num)) lst.Remove(num);
                    else lst.Add(num);
                }
            }
        }
    }
}

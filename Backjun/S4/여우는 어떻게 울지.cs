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
                List<string> lst = new List<string>();
                lst.AddRange(sr.ReadLine().Split());
                while (true)
                {
                    string str = sr.ReadLine();
                    if (str == "what does the fox say?") break;
                    string[] strs = str.Split();
                    lst.RemoveAll(x => x == strs[2]);
                }

                sw.WriteLine(string.Join(" ", lst));
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

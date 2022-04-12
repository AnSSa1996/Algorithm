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

            while (true)
            {
                string str = sr.ReadLine();
                if (str == "-1") break;
                List<int> lst = Array.ConvertAll(str.Split(), int.Parse).ToList();
                lst.RemoveAt(lst.Count - 1);

                int cnt = 0;
                for (int i = 0; i < lst.Count; i++) if (lst.Contains(lst[i] * 2)) cnt++;

                sw.WriteLine(cnt);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int count = 1;
            while (true)
            {
                int N = int.Parse(sr.ReadLine());
                if (N == 0) break;
                List<string> lst = new List<string>();
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < N; i++) lst.Add(sr.ReadLine());
                lst.Sort();
                foreach (var str in lst) sb.AppendLine(str);
                sw.WriteLine(count++);
                sw.Write(sb);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

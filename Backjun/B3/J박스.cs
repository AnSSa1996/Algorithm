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
            StringBuilder resultSb = new StringBuilder();
            int N = int.Parse(sr.ReadLine());
            for (int i = 0; i < N; i++)
            {
                StringBuilder temp = new StringBuilder();
                int box = int.Parse(sr.ReadLine());
                temp.AppendLine(string.Concat(Enumerable.Repeat("#", box)));
                for (int mid = 2; mid < box; mid++)
                {
                    temp.Append("#");
                    temp.Append(string.Concat(Enumerable.Repeat("J", box - 2)));
                    temp.AppendLine("#");
                }
                if (box != 1) temp.AppendLine(string.Concat(Enumerable.Repeat("#", box)));
                resultSb.AppendLine(temp.ToString());
            }

            resultSb.Remove(resultSb.Length - 1, 1);
            sw.Write(resultSb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

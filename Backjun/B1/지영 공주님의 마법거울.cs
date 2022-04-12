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

            List<string> strLst = new List<string>();

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++) strLst.Add(sr.ReadLine());

            int state = int.Parse(sr.ReadLine());

            if (state == 1) for (int i = 0; i < N; i++) resultSb.AppendLine(strLst[i]);
            else if (state == 2) for (int i = 0; i < N; i++) resultSb.AppendLine(new string(strLst[i].Reverse().ToArray()));
            else if (state == 3) for (int i = N - 1; i >= 0; i--) resultSb.AppendLine(strLst[i]);

            sw.WriteLine(resultSb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
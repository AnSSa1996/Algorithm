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
            StringBuilder sb = new StringBuilder();
            int N = int.Parse(sr.ReadLine());
            long cnt = 0;

            Hanoi(N, 1, 3, 2);
            sw.WriteLine(cnt);
            sw.Write(sb);

            void Hanoi(int K, int start, int target, int assistant)
            {
                if (K == 1) { sb.AppendLine($"{start} {target}"); cnt++; return; }
                Hanoi(K - 1, start, assistant, target);
                sb.AppendLine($"{start} {target}");
                cnt++;
                Hanoi(K - 1, assistant, target, start);
            }


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
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

            string Adrian = string.Concat(Enumerable.Repeat("ABC", 50));
            string Bruno = string.Concat(Enumerable.Repeat("BABC", 30));
            string Goran = string.Concat(Enumerable.Repeat("CCAABB", 30));

            List<int> score = Enumerable.Repeat(0, 3).ToList();

            int N = int.Parse(sr.ReadLine());
            string str = sr.ReadLine();

            for (int i = 0; i < N; i++)
            {
                if (Adrian[i] == str[i]) score[0]++;
                if (Bruno[i] == str[i]) score[1]++;
                if (Goran[i] == str[i]) score[2]++;
            }

            int max = score.Max();
            sw.WriteLine(max);

            if (score[0] == max) sw.WriteLine("Adrian");
            if (score[1] == max) sw.WriteLine("Bruno");
            if (score[2] == max) sw.WriteLine("Goran");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
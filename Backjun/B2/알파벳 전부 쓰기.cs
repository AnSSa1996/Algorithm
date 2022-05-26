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

            int N = int.Parse(sr.ReadLine());
            for (int i = 0; i < N; i++)
            {
                int[] letters = new int[26];
                string str = sr.ReadLine().ToLower();
                foreach (var c in str)
                {
                    int num = c - 'a';
                    if (num >= 0 && num <= 25) letters[num]++;
                }
                bool check = true;
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < 26; j++)
                {
                    if (letters[j] == 0) { sb.Append((char)(j + 'a')); check = false; }
                }

                if (check) sw.WriteLine("pangram");
                else sw.WriteLine($"missing {sb}");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

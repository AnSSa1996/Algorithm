using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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

            int[] alpha = new int[26];
            string str = sr.ReadLine();
            bool isOdd = false;
            if (str.Length % 2 == 1) isOdd = true;
            for (int i = 0; i < str.Length; i++) alpha[str[i] - 'A']++;

            int count = 0;
            int index = 0;
            for (int i = 0; i < 26; i++)
            {
                if (count == 2) break;
                if (alpha[i] % 2 == 1)
                {
                    count++;
                    index = i;
                }
            }

            if (count >= 2) sw.WriteLine("I'm Sorry Hansoo");
            else if (count == 1 && isOdd)
            {
                for (int i = 0; i < 26; i++)
                {
                    for (int j = 0; j < (alpha[i] / 2); j++)
                    {
                        sb.Append((char)(i + 'A'));
                    }
                }
                string reverseStr = new string(sb.ToString().Reverse().ToArray());
                sb.Append((char)(index + 'A'));
                sb.Append(reverseStr);
                sw.WriteLine(sb);
            }
            else if (count == 0 && isOdd == false)
            {
                for (int i = 0; i < 26; i++)
                {
                    for (int j = 0; j < (alpha[i] / 2); j++)
                    {
                        sb.Append((char)(i + 'A'));
                    }
                }
                string reverseStr = new string(sb.ToString().Reverse().ToArray());
                sb.Append(reverseStr);
                sw.WriteLine(sb);
            }
            else sw.WriteLine("I'm Sorry Hansoo");


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
